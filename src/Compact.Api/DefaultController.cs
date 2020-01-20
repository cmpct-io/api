using Microsoft.AspNetCore.Mvc;

namespace Compact.Api
{
    public class DefaultController : Controller
    {
        [Route(""), HttpGet]
        public ActionResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger");
        }
    }
}
