using Compact.Infrastructure;
using System.Collections.Generic;
using System.Linq;
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
        private const string CONTAINER_NAME = "comments";

        private readonly IAzureStorageManager _storageManager;

        private Dictionary<string, IEnumerable<Comment>> _cachedComments { get; set; }

        public CommentsDataStore(IAzureStorageManager storageManager)
        {
            _storageManager = storageManager;
            _cachedComments = new Dictionary<string, IEnumerable<Comment>>();
        }

        public async Task<IEnumerable<Comment>> GetAsync(string routeId)
        {
            if (!_cachedComments.Keys.Any(x => routeId.Equals(x, System.StringComparison.OrdinalIgnoreCase)))
            {
                var result = await _storageManager.ReadObject<List<Comment>>(CONTAINER_NAME, $"{routeId}.json");

                _cachedComments.Add(routeId, result);

                return result;
            }

            return _cachedComments.GetValueOrDefault(routeId);
        }

        public async Task AddAsync(Comment comment)
        {
            _cachedComments.Remove(comment.RouteId);

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