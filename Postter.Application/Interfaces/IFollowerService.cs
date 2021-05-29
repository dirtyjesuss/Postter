using System.Threading.Tasks;
using Postter.Domain.Models;

namespace Postter.Application.Interfaces
{
    public interface IFollowerService
    {
        Task AddFollower(Follower follower);
        void RemoveFollower(Follower follower);
    }
}