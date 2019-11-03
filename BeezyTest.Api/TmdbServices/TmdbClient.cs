using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;

namespace BeezyTest.TmdbServices
{
	class TmdbClient : ITmdbClient
	{
		private readonly HttpClient Client;
		private int RequestCounter;
		public TmdbConfig Config { get; }
		public TmdbClient(TmdbConfig config)
		{
			Client = new HttpClient();
			Config = config;
			RequestCounter = 0;
		}
		public async Task<TResult> GetResult<TResult>(string url, IRequestParameters requestParameters)
			where TResult : class, new()
		{
			TResult result;
			if (++RequestCounter > 40)
			{
				//JIB: we could pause here to prevent overrunning our request top
				RequestCounter = 0;
			}
			HttpResponseMessage response = await Client.GetAsync(
				Config.BaseUrl + url + "?api_key=" + Config.ApiKey + "&" + requestParameters.ToString()
			);
			if (response.IsSuccessStatusCode)
			{
				result = JsonConvert.DeserializeObject<TResult>(
					await response.Content.ReadAsStringAsync()
				);
			}
			else
			{
				throw new NotImplementedException();
			}
			return result;
		}
	}
}
