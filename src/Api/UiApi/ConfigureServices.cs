using Microsoft.OpenApi.Models;

namespace UiApi
{
    public static class ConfigureServices
    {
		public static IServiceCollection AddUiApiServices(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Video Call API",
					Description = "Video Call App API",
					Contact = new OpenApiContact { Name = "Portal Admin", Email = "admin@yopmail.com" }
				});
			});
				return services;
        }
    }
}
