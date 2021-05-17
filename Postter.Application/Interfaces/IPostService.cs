using System.Threading.Tasks;
using Postter.Application.ViewModels;
using Postter.Domain.Models;

namespace Postter.Application.Interfaces
{
    public interface IPostService
    {
        PostViewModel GetPostsByUserId(string userId);
        Task AddPost(Post post);
    }
}