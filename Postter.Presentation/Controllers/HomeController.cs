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
namespace Postter.Presentation.Controllers
{
    [Authorize]
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
                var model = new IndexViewModel()
                {
                    CurrentUser = await _userManager.GetUserAsync(User)
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
        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string text, IFormFile uploadedFile)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var post = new Post()
            {
                UserId = currentUser.Id,
                Author = currentUser
            };
            
            post.Text = text ?? "bruh";
            
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