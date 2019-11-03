using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.ResultDto;

namespace BeezyTest.TmdbServices.Actions
{
	class SearchKeywordAction :ITmdbAction
	{
		class RequestDto : IRequestParameters
		{
			const string query = "query";
			public string Query { get; private set; }
			public RequestDto(string query)
			{
				Query = query;
			}
			public override string ToString()
			{
				return query + "=" + Query;
			}
		}
		private RequestDto _Request;

		public IRequestParameters RequestParameters => _Request;
		public string Url(TmdbConfig config) => config.UrlSearchKeyword;

		public SearchKeywordAction(string keyword)
		{
			_Request = new RequestDto(keyword);
		}
		public async Task<PagedResultList<KeywordResultItem>> Execute(ITmdbClient client) =>
			 await client.GetResult<PagedResultList<KeywordResultItem>>(
					Url(client.Config),
					_Request);

	}
}
