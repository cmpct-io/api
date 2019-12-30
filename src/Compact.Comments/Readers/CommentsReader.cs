using System.Collections.Generic;

namespace Compact.Comments
{
    public interface ICommentsReader
    {
        IEnumerable<Comment> Get(string routeId);
    }

    public class CommentsReader : ICommentsReader
    {
        private readonly ICommentsDataStore _dataStore;

        public CommentsReader(ICommentsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Comment> Get(string routeId)
        {
            return _dataStore.Get(routeId);
        }
    }
}
