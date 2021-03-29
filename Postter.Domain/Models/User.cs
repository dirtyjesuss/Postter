using System;
using System.Collections.Generic;
using System.Text;
namespace Postter.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image_path { get; set; }
        public string Bio { get; set; }
    }
}