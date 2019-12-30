using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Compact.Reports
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsReader _reader;
        private readonly IReportWriter _writer;

        public ReportsController(IReportsReader reader, IReportWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        /// <summary>
        /// Get all reports for a specific route
        /// </summary>
        /// <param name="routeId">The route to query</param>
        [HttpGet("/api/routes/{routeId}/reports")]
        [ProducesResponseType(typeof(IEnumerable<Report>), 200)]
        public ActionResult Get(string routeId)
        {
            var response = _reader.Get(routeId);

            return Ok(response);
        }

        /// <summary>
        /// Report a route
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/api/reports")]
        public ActionResult Post(PostReportRequestModel request)
        {
            _writer.Add(request.RouteId, request.Name, request.ReportType);

            return NoContent();
        }
    }
}