using System;

namespace Compact.Comments
{
    public interface ICommentsWriter
    {
        void Add(string routeId, string name, string commentText);
    }

    public class CommentsWriter : ICommentsWriter
    {
        private readonly ICommentsDataStore _dataStore;

        public CommentsWriter(ICommentsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Add(string routeId, string name, string commentText)
        {
            var comment = new Comment
            {
                Id = "comment1",
                RouteId = routeId,
                Name = name,
                CommentText = commentText,
                DateAdded = DateTime.UtcNow
            };

            _dataStore.Add(comment);
        }
    }
}