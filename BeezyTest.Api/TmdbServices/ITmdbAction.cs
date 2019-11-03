using System.Runtime.CompilerServices;
using BeezyTest.TmdbServices.Config;

[assembly:InternalsVisibleTo("TmdbServices.Test")]
namespace BeezyTest.TmdbServices
{
	interface ITmdbAction
	{
		IRequestParameters RequestParameters { get;  }
		string Url(TmdbConfig config);
	}
}
