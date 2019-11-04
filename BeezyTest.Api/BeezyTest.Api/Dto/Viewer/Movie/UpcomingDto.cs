using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeezyTest.Api.Dto.Viewer.Movie
{
	public class UpcomingDto
	{
		public DateTime start_date { get; set; }
		public string[] keywords { get; set; }
		public string[] genres { get; set; }
		public int page { get; set; }
	}
}
