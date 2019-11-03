using BeezyTest.DomainEntities.Media;

namespace BeezyTest.DomainEntities
{
	public class SimpleBillboard
	{
		public struct WeekSchedule
		{
			public Movie[] Screens { get; set; }
		}
		public WeekSchedule[] Schedule { get; protected set; }
		public int WeekCount { get => Schedule.Length; }
		public SimpleBillboard(int weekCount)
		{
			Schedule = new WeekSchedule[weekCount];
		}
	}
}
