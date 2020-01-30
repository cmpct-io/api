using Microsoft.AspNetCore.Mvc;

namespace Compact.Api
{
    public class DefaultController : Controller
    {
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger");
        }
    }
}