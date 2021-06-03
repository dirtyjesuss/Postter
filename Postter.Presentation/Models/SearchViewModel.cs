using System.Collections.Generic;
using Postter.Domain.Models;

namespace Postter.Presentation.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public string SearchString { get; set; }
        public User CurrentUser { get; set; }

        public bool IsFollowingPosts { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}