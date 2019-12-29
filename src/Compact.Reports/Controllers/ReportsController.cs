using Microsoft.AspNetCore.Mvc;

namespace Compact.Reports
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportWriter _writer;

        public ReportsController(IReportWriter writer)
        {
            _writer = writer;
        }

        [HttpPost("/api/reports")]
        public ActionResult Post(PostReportRequestModel request)
        {
            _writer.Add(request.RouteId, request.Name, request.ReportType);

            return NoContent();
        }
    }
}