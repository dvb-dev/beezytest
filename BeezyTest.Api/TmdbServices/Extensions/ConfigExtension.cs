using Microsoft.Extensions.Configuration;

namespace BeezyTest.TmdbServices.Extensions
{
	public static class ConfigExtension
	{
		const string TmdbSection = "TmdbConfig";
		const string ApiKeyEntry = "ApiKey";
		public static string GetTmdbApiKey(this IConfiguration config) => config.GetSection(TmdbSection)[ApiKeyEntry];
	}
}
