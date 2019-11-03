using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.TmdbServices.Config
{
	public class TmdbConfigBuilder
	{
		public readonly TmdbConfig Config;
		public TmdbConfigBuilder()
		{
			Config = new TmdbConfig();
		}
		public TmdbConfigBuilder UseApiKey(string apiKey)
		{
			Config.ApiKey = apiKey;
			return this;
		}
		public TmdbConfigBuilder UseReadAccessToken(string token)
		{
			Config.ReadAccessToken = token;
			return this;
		}
	}
}
