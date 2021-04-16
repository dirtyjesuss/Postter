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
       // [Authorize(Roles = "User, Admin")] //- вот это вот существо редиректало не на те страницы регистрации и авторизации не используйте её, это identity!!
        public IActionResult Index()
        {
            if(User.IsInRole("user")) 
                return View(User);
            return Redirect("/Account/Register");
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}