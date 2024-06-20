using Microsoft.Extensions.Configuration;

namespace Api.Middleware
{
	public static class ConfigurationExtensions
	{
		public static string[] GetOrigins(this IConfiguration configuration)
		{
			return (configuration["Origins"] ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
