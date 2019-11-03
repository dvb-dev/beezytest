using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.Actions
{
	/// <summary>
	/// Encapsulates a "Discover" request.
	/// Note: only the funcionality required for the demo has been implemented.
	/// </summary>
	class DiscoverMovieAction : ITmdbAction
	{
		class RequestDto : IRequestParameters
		{
			const string with_keywords = "with_keywords";
			const string with_genres = "with_genres";
			const string with_release_type = "with_release_types";
			const string primary_release_date_gte = "primary_release_date.gte";
			const string primary_release_date_lte = "primary_release_date.lte";
			const string page = "page";

			public IList<int> Keywords { get; set; }
			public IList<int> Genres { get; set; }
			public IList<int> ReleaseTypes { get; set; }
			public DateTime ReleaseDateMin { get; set; }
			public DateTime ReleaseDateMax { get; set; }
			public int Page { get; set; }

			public RequestDto()
			{
				Keywords = new List<int>();
				Genres = new List<int>();
				ReleaseTypes = new List<int>();
				Page = 0;
			}
			public override string ToString()
			{
				List<string> result = new List<string>();

				if(Page > 0)
				{
					result.Add(page + "=" + Page.ToString());
				}
				if (Keywords.Count > 0)
				{
					result.Add(with_keywords + "=" + String.Join(",", Keywords));
				}
				if (Genres.Count > 0)
				{
					result.Add(with_genres + "=" + String.Join("|", Genres));
				}
				if (ReleaseTypes.Count > 0)
				{
					result.Add(with_release_type + "=" + String.Join(",", ReleaseTypes));
				}
				if (ReleaseDateMin != default(DateTime))
				{
					result.Add(primary_release_date_gte + "=" + ReleaseDateMin.Year + "-" + ReleaseDateMin.Month + "-" + ReleaseDateMin.Day);
				}
				if (ReleaseDateMax != default(DateTime))
				{
					result.Add(primary_release_date_lte + "=" + ReleaseDateMax.Year + "-" + ReleaseDateMax.Month + "-" + ReleaseDateMax.Day);
				}
				return String.Join("&", result);
			}
		}
		private RequestDto _Request;

		public IRequestParameters RequestParameters { get => _Request; }
		public string Url(TmdbConfig config) => config.UrlDiscoverMovie;

		public DiscoverMovieAction()
		{
			_Request = new RequestDto();
		}
		public DiscoverMovieAction SetKeywords(IList<int> keywords)
		{
			_Request.Keywords = keywords;
			return this;
		}
		public DiscoverMovieAction SetGenres(IList<int> genres)
		{
			_Request.Genres = genres;
			return this;
		}
		public DiscoverMovieAction SetReleaseTypes(IList<int> releaseTypes)
		{
			_Request.ReleaseTypes = releaseTypes;
			return this;
		}
		public DiscoverMovieAction SetMinDate(DateTime date)
		{
			_Request.ReleaseDateMin = date;
			return this;
		}
		public DiscoverMovieAction SetMaxDate(DateTime date)
		{
			_Request.ReleaseDateMax = date;
			return this;
		}
		public async Task<PagedResultList<MovieSearchResultItem>> Execute(ITmdbClient client)
		{
			_Request.Page++;
			return await client.GetResult<PagedResultList<MovieSearchResultItem>>(
				Url(client.Config),
				_Request);
		}
	}
}
