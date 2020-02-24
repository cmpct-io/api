using System;
using System.Collections.Generic;

namespace Compact.Routes
{
    /// <summary>
    /// A unique collection of one or more links to other websites
    /// </summary>
    public class Route
    {
        /// <summary>
        /// The unique identifier associated with this route
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A list of one or more links that this route can direct a user too
        /// </summary>
        public IEnumerable<Link> Links { get; set; }

        /// <summary>
        /// A flag that the RouteProcessor has processed the route for metadata
        /// </summary>
        public DateTime? ProcessDate { get; set; }
    }
}