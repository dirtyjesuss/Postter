using System.Collections.Generic;
using Postter.Domain.Models;

namespace Postter.Application.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}