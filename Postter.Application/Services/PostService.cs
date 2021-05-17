using System.Threading.Tasks;
using Postter.Application.Interfaces;
using Postter.Application.ViewModels;
using Postter.Domain.Interfaces;
using Postter.Domain.Models;

namespace Postter.Application.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public PostViewModel GetPostsByUserId(string userId)
        {
            return new PostViewModel()
            {
                Posts = _postRepository.GetPostsByUserId(userId)
            };
        }

        public async Task AddPost(Post post)
        {
            await _postRepository.AddPost(post);
        }
    }
}