using BeezyTest.DomainEntities;
using BeezyTest.DomainEntities.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeezyTest.DomainServices.Billboards
{
	public class BillboardGenerator
	{
		public delegate bool BlockBusterGenreRule(Movie movie);

		public SimpleBillboard Generate(IList<Movie> movies, int weekCount, int screenCount)
		{
			throw new NotImplementedException();
		}
		public AdvancedBillboard Generate(IList<Movie> movies, int weekCount, int bigScreenCount, int smallScreenCount, BlockBusterGenreRule isBlockBusterGenre)
		{
			AdvancedBillboard result = new AdvancedBillboard(weekCount);
			Queue<Movie> bigMovies = new Queue<Movie>(movies.Where(x => isBlockBusterGenre(x)));
			Queue<Movie> smallMovies = new Queue<Movie>(movies.Where(x => !isBlockBusterGenre(x)));

			if (weekCount * bigScreenCount > bigMovies.Count)
			{
				throw new InsufficientItemsException(weekCount * bigScreenCount, bigMovies.Count);
			}
			else if (weekCount * smallScreenCount > smallMovies.Count)
			{
				throw new InsufficientItemsException(weekCount * smallScreenCount, smallMovies.Count);
			}
			else
			{
				for(int w = 0; w < weekCount; w++)
				{
					result.Schedule[w].BigScreens = CreateWeekSchedule(bigMovies, bigScreenCount);
					result.Schedule[w].SmallScreens = CreateWeekSchedule(smallMovies, smallScreenCount);
				}
			}
			return result;
		}
		private Movie[] CreateWeekSchedule(Queue<Movie> movieStack, int screenCount)
		{
			Movie[] schedule = new Movie[screenCount];
			for (int s = 0; s < screenCount; s++)
			{ 
				schedule[s] = movieStack.Dequeue();
			}
			return schedule;
		}
	}
}
