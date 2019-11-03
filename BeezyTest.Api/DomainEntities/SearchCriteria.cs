using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.DomainEntities
{
	public class SearchCriteria
	{
		public bool UpcomingOnly { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IList<string> Genres { get; set; }
		public IList<string> Keywords { get; set; }
		public SearchCriteria()
		{

		}
		public SearchCriteria(SearchCriteria source)
		{
			UpcomingOnly = source.UpcomingOnly;
			StartDate = source.StartDate;
			EndDate = source.EndDate;
			Genres = new List<string>(source.Genres);
			Keywords = new List<string>(source.Keywords);
		}
	}
}
