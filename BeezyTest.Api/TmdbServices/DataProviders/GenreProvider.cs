using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Actions;
using BeezyTest.TmdbServices.DataProviders.Cache;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.DataProviders
{
	class GenreProvider
	{
		private ITmdbClient _Client;
		private SimpleCache<GenreResultList.GenreEntry> _Cache;
		private bool _Initialized;
		public GenreProvider(ITmdbClient client, SimpleCache<GenreResultList.GenreEntry> cache)
		{
			_Client = client;
			_Cache = cache;
			_Initialized = false;
		}
		/// <summary>
		/// Loads the full list of genres into the cache
		/// As the genre list is very limited and will not change rapidly, the entire list is cached locally the first time it's needed
		/// NOTE: For simplicity, language en-US is assumed.
		/// </summary>
		/// <returns></returns>
		private async Task Initialize()
		{
			LoadGenreListAction action = new LoadGenreListAction()
				.SetLanguage("en-US");	//Hard-coded default for now; 
			var genreList = await action.Execute(_Client);
			_Cache.StoreItems(genreList.genres);
			_Initialized = true;
		}
		public int GetGenreId(string genre)
		{
			if( !_Initialized)
			{
				Task.Run(() => Initialize()).GetAwaiter().GetResult();
			}
			var result = _Cache.GetByName(genre);
			return (result == null) ? 0 : result.id;
		}
		public IList<int> GetGenreIds(IList<string> genres)
		{
			IList<int> result = new List<int>();
			foreach (var item in genres)
			{
				result.Add(GetGenreId(item));
			}
			return result;
		}
		public string GetGenreName(int id)
		{
			if( !_Initialized)
			{
				Task.Run(() => Initialize()).GetAwaiter().GetResult();
			}
			var result = _Cache.GetById(id);
			if (result == null)
			{
				throw new NotImplementedException();
			}
			else
			{
				return result.name;
			}
		}
	}
}
