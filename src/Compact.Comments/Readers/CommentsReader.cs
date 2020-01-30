using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compact.Comments
{
    public interface ICommentsReader
    {
        Task<IEnumerable<Comment>> GetAsync(string routeId);
    }

    public class CommentsReader : ICommentsReader
    {
        private readonly ICommentsDataStore _dataStore;

        public CommentsReader(ICommentsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<Comment>> GetAsync(string routeId) =>
            await _dataStore.GetAsync(routeId);
    }
}