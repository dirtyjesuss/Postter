using System.Threading.Tasks;
using Postter.Domain.Models;

namespace Postter.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task AddFollower(Follower follower);
        void RemoveFollower(Follower follower);
    }
}