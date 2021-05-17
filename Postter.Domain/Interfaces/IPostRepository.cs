using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Postter.Domain.Models;

namespace Postter.Domain.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostsByUserId(string userId);
        Task AddPost(Post post);
    }
}