using Postter.Application.ViewModels;
using Postter.Domain.Models;

namespace Postter.Presentation.Models
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public User CurrentUser { get; set; }
        public bool IsCurrentUser { get; set; }
        public PostViewModel PostViewModel { get; set; }
    }
}