using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Actions;
using BeezyTest.TmdbServices.DataProviders.Cache;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.DataProviders
{
	class MovieProvider
	{
		private ITmdbClient _Client;
		private SimpleCache<MovieSearchResultItem> _Cache;
		public MovieProvider(ITmdbClient client, SimpleCache<MovieSearchResultItem> cache)
		{
			_Client = client;
			_Cache = cache;
		}
		public async Task<int> GetMovieId(string title)
		{
			var movie = _Cache.GetByName(title);
			if (movie == null)
			{
				movie = await SearchMovie(title);
			}
			return (movie == null) ? 0 : movie.id;
		}
		private async Task<MovieSearchResultItem> SearchMovie(string title )
		{ 
			SearchMovieAction action = new SearchMovieAction(title);
			var movieList = await action.Execute(_Client);
			_Cache.StoreItems(movieList.results);
			return _Cache.GetByName(title);
		}
	}
}
