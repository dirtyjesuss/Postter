using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Postter.Infrastructure.Data.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Postter.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Postter.Infrastructure.Data;

namespace Postter.Presentation.Controllers
{
    [ApiController]
   [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, ApplicationDbContext context)
        {
            db = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            string username = Convert.ToString(HttpContext.Request.Query["userid"]);
            if (HttpContext.Request.Query["userid"].ToString() != "")
            {
                User user = await _userManager.FindByNameAsync(username);
                List<User> us = new List<User>();
                us.Add(user);
                return us;
            }

            return await db.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            
            var currentUserId = _userManager.GetUserId(User);
            User user;
            if (id =='0'.ToString()) 
            {
                user = await _userManager.FindByIdAsync(currentUserId);
                return new ObjectResult(user);
            }
            else
            {
                user = await _userManager.FindByNameAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                return new ObjectResult(user);
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Put(User changeUser)
        {
            var oldUser = await _userManager.FindByEmailAsync(changeUser.Email);
            if (oldUser == null)
            {
                return BadRequest();
            }
            bool checkPassword= await _userManager.CheckPasswordAsync(oldUser, changeUser.Password);
            if (!checkPassword)
            {
                return BadRequest();
            }

            oldUser.Bio = changeUser.Bio == null? oldUser.Bio: changeUser.Bio;
            oldUser.UserName = changeUser.UserName == null ? oldUser.UserName:changeUser.UserName;
            oldUser.Image_path = changeUser.Image_path == null? oldUser.Image_path: changeUser.Image_path;

            await _userManager.UpdateAsync(oldUser);
            return Ok(changeUser);
        }
    }
}