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
	class KeywordProvider
	{
		private ITmdbClient _Client;
		private SimpleCache<KeywordResultItem> _Cache;
		public KeywordProvider(ITmdbClient client, SimpleCache<KeywordResultItem> cache)
		{
			_Client = client;
			_Cache = cache;
		}
		public async Task<int> GetKeywordId(string keyword)
		{
			var keywordItem = _Cache.GetByName(keyword);
			if (keywordItem == null)
			{
				keywordItem = await SearchKeyword(keyword);
			}
			return (keywordItem == null) ? 0 : keywordItem.id;
		}
		public async Task<IList<int>> GetKeywordIds(IList<string> keywords)
		{
			IList<int> result = new List<int>();
			foreach (var item in keywords)
			{
				result.Add(await GetKeywordId(item));
			}
			return result;
		}
		public async Task<string> GetKeywordName(int id)
		{
			var keywordItem = _Cache.GetById(id);
			if(keywordItem == null)
			{
				keywordItem = await SearchKeyword(id);
			}
			return (keywordItem == null) ? "" : keywordItem.name;
		}
		private async Task<KeywordResultItem> SearchKeyword(string keyword )
		{ 
			SearchKeywordAction action = new SearchKeywordAction(keyword);
			var kwList = await action.Execute(_Client);
			_Cache.StoreItems(kwList.results);
			return _Cache.GetByName(keyword);
		}
		private async Task<KeywordResultItem> SearchKeyword(int id)
		{
			throw new NotImplementedException();
		}
	}
}
