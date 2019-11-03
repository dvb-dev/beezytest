using BeezyTest.TmdbServices.DataProviders.Cache;

namespace BeezyTest.TmdbServices.ResultDto
{
	class KeywordResultItem : IIdNamePair
	{
		public string name { get; set; }
		public int id { get; set; }
	}
}
