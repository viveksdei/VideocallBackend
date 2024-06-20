using Api.Middleware;
using Core.App.Common.Interfaces;
using Infrastructure.Persistence.DapperData;
using Infrastructure.Persistence.EfCoreData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ConfigureServices
    {

        public static IServiceCollection AddInfrastructurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.UseDateOnlyTimeOnly();
                        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    }));

            services.AddCorsWithPolicy(configuration.GetOrigins());
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddSingleton<IDapperDbContext, DapperDbContext>();

            return services;
        }
    }
}
