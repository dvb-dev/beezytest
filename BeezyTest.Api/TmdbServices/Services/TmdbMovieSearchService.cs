using BeezyTest.DomainEntities;
using BeezyTest.DomainEntities.Media;
using BeezyTest.DomainServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Actions;
using BeezyTest.TmdbServices.DataProviders;
using BeezyTest.TmdbServices.DataProviders.Cache;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.Services
{
	class TmdbMovieSearchService : IMovieSearchService

	{
		private ITmdbClient _Client;
		private GenreProvider _GenreProvider;
		private KeywordProvider _KeywordProvider;
		private MovieProvider _MovieProvider;
		public TmdbMovieSearchService(
			ITmdbClient client, 
			GenreProvider genreProvider, 
			KeywordProvider keywordProvider,
			MovieProvider movieProvider)
		{
			_Client = client;
			_GenreProvider = genreProvider;
			_KeywordProvider = keywordProvider;
			_MovieProvider = movieProvider;
		}
		public async Task<IList<Movie>> GetMoviesByCriteria(SearchCriteria criteria)
		{
			//Prepare action
			DiscoverMovieAction action = await CreateDiscoveryAction(criteria);

			//Execute discovery action
			/* OUT for NOW, only get 1 page of results
			List<MovieSearchResultItem> results = new List<MovieSearchResultItem>();
			PagedResultList<MovieSearchResultItem> discoveryResult;
			do
			{
				discoveryResult = await action.Execute(_Client);
				results.AddRange(discoveryResult.results);
			}
			while (discoveryResult.page < discoveryResult.total_pages);
			//Get movie details
			IList<MovieDetailsResultItem> movieDetails = await GetMovieDetails(results);*/

			PagedResultList<MovieSearchResultItem> discoveryResult = await action.Execute(_Client);

			//Get movie details
			IList<MovieDetailsResultItem> movieDetails = await GetMovieDetails(discoveryResult.results);

			//Process results
			List<Movie> result = new List<Movie>();
			foreach (var item in movieDetails)
			{
				result.Add(TransformToDomain(item));
			}
			return result;
		}
		public async Task<Movie> GetMovieByTitle(string title)
		{
			var movieId = await _MovieProvider.GetMovieId(title);
			var movie = await GetMovieDetail(movieId);
			if (movie != null)
			{
				return TransformToDomain(movie);
			}
			return null;
		}
		private async Task<DiscoverMovieAction> CreateDiscoveryAction(SearchCriteria criteria)
		{
			DiscoverMovieAction action = new DiscoverMovieAction()
				.SetGenres(_GenreProvider.GetGenreIds(criteria.Genres))
				.SetMaxDate(criteria.EndDate)
				.SetKeywords(await _KeywordProvider.GetKeywordIds(criteria.Keywords));
			if (criteria.UpcomingOnly)
			{
				action.SetReleaseTypes(new List<int> { 2, 3 });
				action.SetMinDate(DateTime.Now);
			}
			return action;
		}
		private async Task<IList<MovieDetailsResultItem>> GetMovieDetails(IEnumerable<IIdNamePair> movieList)
		{
			List<MovieDetailsResultItem> result = new List<MovieDetailsResultItem>();
			foreach (var item in movieList)
			{
				var movie = await GetMovieDetail(item.id);
				if (movie != null)
				{
					result.Add(movie);
				}
			}
			return result;
		}
		private async Task<MovieDetailsResultItem> GetMovieDetail(int movieId)
		{
			var action = new GetMovieDetailsAction(movieId)
				.AppendRequest(GetMovieDetailsAction.AppendedRequest.keywords);
			return await action.Execute(_Client);
		}
		private Movie TransformToDomain(MovieDetailsResultItem item)
		{
			return new Movie {
				Title = item.title,
				Overview = item.overview,
				Genres = item.genres.ToList().Select(x => x.name),
				Language = item.original_language,
				ReleaseDate = (item.release_date != "")?DateTime.ParseExact(item.release_date, "yyyy-MM-dd", CultureInfo.InvariantCulture):default(DateTime),
				WebSite = item.homepage,
				Keywords = (item.keywords != null)?item.keywords.keywords.ToList().Select(x => x.name):new List<string>()
			};
		}
	}
}
