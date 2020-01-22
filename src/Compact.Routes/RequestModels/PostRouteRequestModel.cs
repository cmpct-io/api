using System.Collections.Generic;

namespace Compact.Routes
{
    public class PostRouteRequestModel
    {
        public string RouteId { get; set; }

        public List<string> Links { get; set; }

        public string Password { get; set; }
    }
}