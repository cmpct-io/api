using System;
using System.Threading.Tasks;

namespace Compact.Comments
{
    public interface ICommentsWriter
    {
        Task AddAsync(string routeId, string name, string commentText);
    }

    public class CommentsWriter : ICommentsWriter
    {
        private readonly ICommentsDataStore _dataStore;

        public CommentsWriter(ICommentsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task AddAsync(string routeId, string name, string commentText)
        {
            var comment = new Comment
            {
                RouteId = routeId,
                Name = name,
                Text = commentText,
                Added = DateTime.UtcNow
            };

            await _dataStore.AddAsync(comment);
        }
    }
}