using System.Collections.Generic;
using System.Linq;

namespace Compact.Comments
{
    public interface ICommentsDataStore
    {
        IEnumerable<Comment> Get(string routeId);

        void Add(Comment comment);
    }

    public class CommentsDataStore : ICommentsDataStore
    {
        private List<Comment> _comments = new List<Comment>();

        public IEnumerable<Comment> Get(string routeId)
        {
            return _comments.Where(comment => routeId.Equals(comment.RouteId, System.StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}