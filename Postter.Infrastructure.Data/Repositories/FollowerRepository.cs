using System.Linq;
using System.Threading.Tasks;
using Postter.Domain.Interfaces;
using Postter.Domain.Models;
using Postter.Infrastructure.Data.Context;

namespace Postter.Infrastructure.Data.Repositories
{
    public class FollowerRepository: IFollowerRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFollower(Follower follower)
        {
            await _context.Followers.AddAsync(follower);
            await _context.SaveChangesAsync();
        }

        public void RemoveFollower(Follower follower)
        {
            var followerToRemove = _context.Followers.FirstOrDefault(f => f.UserId == follower.UserId && f.FollowsId == follower.FollowsId);
            if (followerToRemove == null) return;
            _context.Followers.Remove(followerToRemove);
            _context.SaveChanges();
        }
    }
}