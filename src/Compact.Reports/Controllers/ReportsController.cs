using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetAsync(string routeId) =>
            Ok(await _reader.GetAsync(routeId));

        /// <summary>
        /// Report a route
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/api/reports")]
        public async Task<ActionResult> PostAsync(PostReportRequestModel request)
        {
            await _writer.AddAsync(request.RouteId, request.Name, request.ReportType);

            return NoContent();
        }
    }
}