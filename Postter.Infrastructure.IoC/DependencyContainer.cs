using Microsoft.Extensions.DependencyInjection;

namespace Postter.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Postter.Application
            //services.AddScoped<..., ...>();

            //Postter.Domain.Interfaces | Postter.Infrastructure.Data.Repositories
            //services.AddScoped<..., ...>();
        }
    }
}