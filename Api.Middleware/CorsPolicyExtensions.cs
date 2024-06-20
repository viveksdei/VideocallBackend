using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Middleware
{
	/// <summary>
	/// Reference: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0
	/// </summary>
	public static class CorsPolicyExtensions
	{
		private const string POLICY_NAME = "AllowAllOrigins";

		public static void AddCorsWithPolicy(this IServiceCollection services, params string[] origins)
			=> services.AddCors(options =>
			{
				options.AddPolicy(POLICY_NAME, builder =>
				{
					builder.SetIsOriginAllowedToAllowWildcardSubdomains()
						.WithOrigins(origins)
						//.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.WithExposedHeaders("Content-Disposition", "Content-Length")
						//.WithHeaders("subdomain")
						.AllowCredentials();
				});
			});

		public static void UseCorsWithPolicy(this IApplicationBuilder app) => app.UseCors(POLICY_NAME);
	}
}
