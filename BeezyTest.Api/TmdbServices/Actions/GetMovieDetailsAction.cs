using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.Actions
{
	class GetMovieDetailsAction : ITmdbAction
	{
		public enum AppendedRequest
		{
			keywords
		}
		class RequestDto : IRequestParameters
		{
			const string language = "language";
			const string append_to_response = "append_to_response";
			public int MovieId { get; set; }
			public string Language { get; set; }
			public IList<AppendedRequest> AppendToResponse { get; set; }
			public RequestDto(int movieId)
			{
				MovieId = movieId;
				AppendToResponse = new List<AppendedRequest>();
			}
			public override string ToString()
			{
				List<string> query = new List<string>();
				if (Language != null)
				{
					query.Add(language + "=" + Language);
				}
				if (AppendToResponse.Count > 0)
				{
					query.Add(append_to_response + "=" + String.Join(",", AppendToResponse));
				}
				return String.Join("&", query);
			}

	}
		private RequestDto _Request;

		public IRequestParameters RequestParameters => _Request;

		public string Url(TmdbConfig config) => config.UrlGetMovie + "/" + _Request.MovieId.ToString();
		public GetMovieDetailsAction(int movieId)
		{
			_Request = new RequestDto(movieId);
		}
		public GetMovieDetailsAction SetLanguage(string language)
		{
			_Request.Language = language;
			return this;
		}
		public GetMovieDetailsAction AppendRequest(AppendedRequest request)
		{
			_Request.AppendToResponse.Add(request);
			return this;
		}
		public async Task<MovieDetailsResultItem> Execute(ITmdbClient client) =>
			 await client.GetResult<MovieDetailsResultItem>(
					Url(client.Config),
					_Request);

	}
}
