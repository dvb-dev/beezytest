using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeezyTest.Api.Dto.Cinema.Billboard
{
	public class BuildAdvancedDto
	{
		[BindRequired]
		public int? cityId { get; set; }
		[BindRequired]
		public int? weekCount { get; set; }
		public int bigScreenCount { get; set; }
		public int smallScreenCount { get; set; }
		public bool useBoxOfficeData { get; set; }
		public bool upcomingOnly { get; set; }
		public string[] keywords { get; set; }
		public string[] genres { get; set; }
	}
}
