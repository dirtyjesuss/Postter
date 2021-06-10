using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Postter.Domain.Models;
using Postter.Presentation.Models;

namespace Postter.Presentation.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private Task<User> CurrentUser => _userManager.GetUserAsync(User);

        public NotificationsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel
            {
                CurrentUser = await CurrentUser
            };
            return View(model);
        }
    }
}