using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Postter.Domain.Models;

namespace Postter.Presentation.Controllers
{
    public class StaticController : Controller
    {

        public IActionResult About()
        {
            return View();
        }
    }
}