using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Postter.Application.ViewModels;
using Postter.Domain.Models;
using Postter.Presentation.Models;

namespace Postter.Presentation.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        
        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        [Route("Profile/Profile/")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Profile(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            id ??= currentUser.Id;
            
            var user = await _userManager.FindByIdAsync(id);

            var model = new ProfileViewModel
            {
                CurrentUser = user,
                IsCurrentUser = user.Id == currentUser.Id
            };
            return View(model);
        }
    }
}