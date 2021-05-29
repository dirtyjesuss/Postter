using Microsoft.Extensions.DependencyInjection;
using Postter.Application.Interfaces;
using Postter.Application.Services;
using Postter.Domain.Interfaces;
using Postter.Infrastructure.Data.Repositories;

namespace Postter.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Postter.Application
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IFollowerService, FollowerService>();

            //Postter.Domain.Interfaces | Postter.Infrastructure.Data.Repositories
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFollowerRepository, FollowerRepository>();
        }
    }
}