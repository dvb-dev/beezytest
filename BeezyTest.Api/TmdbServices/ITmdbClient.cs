using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;

namespace BeezyTest.TmdbServices
{
	interface ITmdbClient
	{
		TmdbConfig Config { get; }
		Task<TResult> GetResult<TResult>(string url, IRequestParameters requestParameters)
			where TResult : class, new();
	}
}
