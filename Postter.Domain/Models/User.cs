using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace Postter.Domain.Models
{
    public class User : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image_path { get; set; }
        [Required(ErrorMessage = "Укажите что-то о себе")]
        public string Bio { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}