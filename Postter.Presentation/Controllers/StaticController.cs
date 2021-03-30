using Microsoft.AspNetCore.Mvc;

namespace Postter.Presentation.Controllers
{
    [Route("static/[controller]")]
    public class StaticController : Controller
    {
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}