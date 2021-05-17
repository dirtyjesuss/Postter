using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postter.Domain.Interfaces;
using Postter.Domain.Models;
using Postter.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;


namespace Postter.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return _context.Posts.Where(p => p.UserId == userId);
        }

        public async Task AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }
    }
}