using System.Collections.Generic;

namespace BeezyTest.TmdbServices.ResultDto
{
	class PagedResultList<T>
	{
		public int page { get; set; }
		public IList<T> results { get; set; }
		public int total_results { get; set; }
		public int total_pages { get; set; }
	}
}
