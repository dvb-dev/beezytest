using System.Collections.Generic;
using BeezyTest.TmdbServices.DataProviders.Cache;

namespace BeezyTest.TmdbServices.ResultDto
{
	class GenreResultList
	{
		public class GenreEntry : IIdNamePair
		{
			public int id { get; set; }
			public string name { get; set; }
		}
		public IList<GenreEntry> genres { get; set; }
	}
}
