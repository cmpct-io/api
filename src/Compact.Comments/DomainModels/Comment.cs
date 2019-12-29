using System;

namespace Compact.Comments
{
    public class Comment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RouteId { get; set; }

        public string CommentText { get; set; }

        public DateTime DateAdded { get; set; }
    }
}