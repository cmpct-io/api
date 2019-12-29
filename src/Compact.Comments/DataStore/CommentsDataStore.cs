using System.Collections.Generic;

namespace Compact.Comments
{
    public interface ICommentsDataStore
    {
        void Add(Comment comment);
    }

    public class CommentsDataStore : ICommentsDataStore
    {
        private List<Comment> _comments = new List<Comment>();

        public void Add(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}