using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Postter.Application.Interfaces;
using Postter.Application.ViewModels;
using Postter.Domain.Models;
using Postter.Presentation.Models;

namespace Postter.Presentation.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly IFollowerService _followerService;

        private Task<User> CurrentUser => _userManager.GetUserAsync(User);

        public ProfileController(UserManager<User> userManager, IFollowerService followerService)
        {
            _userManager = userManager;
            _followerService = followerService;
        }
        
        public async Task<IActionResult> Profile(string id)
        {
            var currentUser = await CurrentUser;

            id ??= currentUser.Id;
            
            var user = await _userManager.FindByIdAsync(id);

            var model = new ProfileViewModel
            {
                User = user,
                CurrentUser = currentUser,
                IsCurrentUser = user.Id == currentUser.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Follow(string followingUserId)
        {
            var currentUser = await CurrentUser;
            var followingUser = await _userManager.FindByIdAsync(followingUserId);

            var follower = new Follower
            {
                UserId = currentUser.Id,
                FollowsId = followingUserId
            };

            if (currentUser.IsFollows(followingUserId))
            {
                _followerService.RemoveFollower(follower);
            }
            else
            {
                await _followerService.AddFollower(follower);
            }
            
            var model = new ProfileViewModel
            {
                User = followingUser,
                CurrentUser = currentUser
            };
            return PartialView("_FollowButton", model);
        }
    }
}