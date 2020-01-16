using Compact.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compact.Comments
{
    public interface ICommentsDataStore
    {
        Task<IEnumerable<Comment>> GetAsync(string routeId);

        Task AddAsync(Comment comment);
    }

    public class CommentsDataStore : ICommentsDataStore
    {
        private readonly IAzureStorageManager _storageManager;

        private const string CONTAINER_NAME = "comments";

        public CommentsDataStore(IAzureStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public async Task<IEnumerable<Comment>> GetAsync(string routeId)
            => await _storageManager.ReadObject<List<Comment>>(CONTAINER_NAME, $"{routeId}.json");

        public async Task AddAsync(Comment comment)
        {
            var fileName = $"{comment.RouteId}.json";
            var existingFile = await _storageManager.ReadObject<List<Comment>>(CONTAINER_NAME, fileName);

            if (existingFile == null)
            {
                await _storageManager.StoreObject(
                    CONTAINER_NAME,
                    fileName,
                    new List<Comment> { comment });
            }
            else
            {
                existingFile.Add(comment);

                await _storageManager.StoreObject(CONTAINER_NAME, fileName, existingFile);
            }
        }
    }
}