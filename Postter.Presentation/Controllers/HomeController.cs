using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postter.Presentation.Models;
using Postter.Application.ViewModels;
using Postter.Domain.Models;
namespace Postter.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) 
                return Content(User.Identity.Name);
            return Content("не аутентифицирован");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return Content("Authorized");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}