using Microsoft.AspNetCore.Mvc;

namespace Compact.Impressions
{
    [ApiController]
    public class ImpressionsController : ControllerBase
    {
        private readonly IImpressionsWriter _writer;

        public ImpressionsController(IImpressionsWriter writer)
        {
            _writer = writer;
        }

        [HttpPost("/api/impressions")]
        public ActionResult Post(PostImpressionRequestModel request)
        {
            _writer.Add(request.RouteId);

            return NoContent();
        }
    }
}