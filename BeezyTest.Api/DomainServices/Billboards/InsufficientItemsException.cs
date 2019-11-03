using System;

namespace BeezyTest.DomainServices.Billboards
{
	public class InsufficientItemsException : Exception
	{
		public InsufficientItemsException(int required, int received)
		: base($"Insufficient results found to build the schedule: required {required} but found {received}")
		{
			
		}
	}
}
