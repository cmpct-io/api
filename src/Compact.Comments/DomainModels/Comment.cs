using System;

namespace Compact.Comments
{
    public class Comment
    {
        public string Name { get; set; }

        public string RouteId { get; set; }

        public string Text { get; set; }

        public DateTime Added { get; set; }
    }
}