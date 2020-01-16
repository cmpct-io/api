using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Get details about a specific route
        /// </summary>
        [HttpGet("/api/routes/{routeId}")]
        [ProducesResponseType(typeof(Route), 200)]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync(string routeId, string password)
        {
            var response = await _routesReader.GetAsync(routeId);

            if (response == null)
            {
                return NotFound();
            }

            if (InvalidPassword(password, response.Password))
            {
                return BadRequest("Password provided does not match");
            }

            return Ok(response);
        }

        /// <summary>
        /// Create a new route
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("/api/routes")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> PostAsync(PostRouteRequestModel request)
        {
            await _routesWriter.CreateAsync(request.RouteId, request.Target, request.Password);

            return NoContent();
        }

        private bool InvalidPassword(string requestPassword, string actualPassword)
        {
            return
                !string.IsNullOrEmpty(requestPassword)
                && !string.IsNullOrEmpty(actualPassword)
                && !requestPassword.Equals(actualPassword);
        }
    }
}