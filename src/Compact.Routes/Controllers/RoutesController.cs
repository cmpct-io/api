using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Compact.Routes
{
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesReader _routesReader;
        private readonly IRoutesWriter _routesWriter;

        public RoutesController(
            IRoutesReader routesReader,
            IRoutesWriter routesWriter)
        {
            _routesReader = routesReader;
            _routesWriter = routesWriter;
        }

        /// <summary>
        /// GET all routes
        /// </summary>
        [HttpGet("/api/routes")]
        [ProducesResponseType(typeof(IEnumerable<Route>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            var response = _routesReader.Get();

            return Ok(response);
        }

        /// <summary>
        /// Get details about a specific route
        /// </summary>
        [HttpGet("/api/routes/{routeId}")]
        [ProducesResponseType(typeof(Route), 200)]
        public ActionResult<IEnumerable<string>> Get(string routeId)
        {
            var response = _routesReader.Get(routeId);

            return Ok(response);
        }

        /// <summary>
        /// Create a new route
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("/api/routes")]
        [ProducesResponseType(204)]
        public ActionResult Post(PostRouteRequestModel request)
        {
            _routesWriter.Create(request.Id, request.Target);

            return NoContent();
        }
    }
}