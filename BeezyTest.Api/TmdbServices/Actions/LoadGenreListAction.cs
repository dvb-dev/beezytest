using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.Actions
{
	class LoadGenreListAction : ITmdbAction
	{
		class RequestDto : IRequestParameters
		{
			const string language = "language";
			public string Language { get; set; }
			public RequestDto()
			{
			}
			public override string ToString()
			{
				var result = "";
				if (Language != null)
				{
					result = language + "=" + Language;
				}
				return result;
			}
		}
		private RequestDto _Request;

		public IRequestParameters RequestParameters => _Request;
		public string Url(TmdbConfig config) => config.UrlListGenres;

		public LoadGenreListAction SetLanguage(string language)
		{
			_Request.Language = language;
			return this;
		}
		public LoadGenreListAction()
		{
			_Request = new RequestDto();
		}
		public async Task<GenreResultList> Execute(ITmdbClient client) =>
			await client.GetResult<GenreResultList>(
				Url(client.Config),
				_Request);

	}
}
