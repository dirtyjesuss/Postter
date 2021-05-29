using System.Threading.Tasks;
using Postter.Application.Interfaces;
using Postter.Domain.Interfaces;
using Postter.Domain.Models;

namespace Postter.Application.Services
{
    public class FollowerService: IFollowerService
    {
        private readonly IFollowerRepository _repository;

        public FollowerService(IFollowerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddFollower(Follower follower)
        {
            await _repository.AddFollower(follower);
        }

        public void RemoveFollower(Follower follower)
        {
            _repository.RemoveFollower(follower);
        }
    }
}