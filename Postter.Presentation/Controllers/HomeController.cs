using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Postter.Application.Interfaces;
using Postter.Presentation.Models;
using Postter.Application.ViewModels;
using Postter.Domain.Models;
using Postter.Infrastructure.Data.Context;

namespace Postter.Presentation.Controllers
{
    [Authorize(Roles = "employee,admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly IPostService _postService;
        
        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, IWebHostEnvironment appEnvironment, Microsoft.AspNetCore.Identity.UserManager<User> userManager, IPostService postService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _postService = postService;
        }
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var posts = currentUser.Following
                    .Select(f => f.Follows)
                    .Select(u => u.Posts)
                    .SelectMany(p => p)
                    .Concat(currentUser.Posts)
                    .OrderByDescending(p => p.PostedTime).ToList();
                var model = new IndexViewModel
                {
                    CurrentUser = currentUser,
                    PostViewModel = new PostViewModel { Posts = posts }
                };
                return View(model);
            }
            return Redirect("/Account/Register");
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> About()
        {
            var model = new IndexViewModel
            {
                CurrentUser = await _userManager.GetUserAsync(User),
                PostViewModel = null
            };
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public async Task<IActionResult> Search(string searchString, bool isFollowingPosts = false, int page = 1)
        {
            var pageSize = 4;
            
            var currentUser = await _userManager.GetUserAsync(User);
            
            var posts = _postService.GetPostsBySearchString(searchString).Posts;
            if (isFollowingPosts)
            {
                posts = posts.Where(p => currentUser.Following.Any(f => f.FollowsId == p.Author.Id));
            }

            var count = posts.Count();
            var items = posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new SearchViewModel
            {
                CurrentUser = currentUser,
                Posts = items,
                SearchString = searchString,
                IsFollowingPosts = isFollowingPosts,
                PageViewModel = new PageViewModel(count, page, pageSize)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string text, IFormFile uploadedFile)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var post = new Post
            {
                UserId = currentUser.Id, 
                Author = currentUser, 
                PostedTime = DateTime.Now, 
                Text = text ?? "bruh"
            };
            
            if (uploadedFile != null)
            {
                var path = "/files/" + uploadedFile.FileName;
                
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                
                post.AttachmentPath = path;
            }

            await _postService.AddPost(post);
            
            return PartialView("_Post", post);
        }
    }
}