#nullable enable
using Postter.Application.ViewModels;
using Postter.Domain.Models;

namespace Postter.Presentation.Models
{
    public class IndexViewModel
    {
        public User? CurrentUser { get; set; }
        public PostViewModel? PostViewModel { get; set; }
    }
}