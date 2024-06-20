using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
