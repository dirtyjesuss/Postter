using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace Postter.Domain.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Posts = new List<Post>();
            Followers = new List<Follower>();
            Following = new List<Follower>();
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image_path { get; set; }
        [Required(ErrorMessage = "Укажите что-то о себе")]
        public string Bio { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Follower> Following { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public bool IsFollows(string userId)
        {
            return Following?.Any(f => f.FollowsId == userId) ?? false;
        }
    }
}