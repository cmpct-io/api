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

        [HttpGet("/api/routes")]
        [ProducesResponseType(typeof(IEnumerable<Route>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            var response = _routesReader.Get();

            return Ok(response);
        }

        [HttpGet("/api/routes/{shortcut}")]
        [ProducesResponseType(typeof(Route), 200)]
        public ActionResult<IEnumerable<string>> Get(string shortcut)
        {
            var response = _routesReader.Get(shortcut);

            return Ok(response);
        }

        [HttpPost("/api/routes")]
        public ActionResult Post(PostRouteRequestModel request)
        {
            _routesWriter.Create(request.Id, request.Target, request.Shortcut);

            return NoContent();
        }
    }
}