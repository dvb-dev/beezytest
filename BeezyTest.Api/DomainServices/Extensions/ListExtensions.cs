using System.Collections.Generic;

namespace BeezyTest.DomainServices.Extensions
{
	static class ListExtensions
	{
		public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> range)
		{
			if(list is List<T> concreteList)
			{
				concreteList.AddRange(range);
			}
			else
			{
				foreach(var item in range)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}
}
