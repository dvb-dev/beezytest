using BeezyTest.DomainEntities.Media;

namespace BeezyTest.DomainEntities
{
	public class AdvancedBillboard
	{
		public struct WeekSchedule
		{
			public Movie[] BigScreens { get; set; }
			public Movie[] SmallScreens { get; set; }
		}
		public WeekSchedule[] Schedule { get; protected set; }
		public int WeekCount { get => Schedule.Length; }
		public AdvancedBillboard(int weekCount)
		{
			Schedule = new WeekSchedule[weekCount];
		}
	}
}
