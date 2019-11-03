using BeezyTest.DomainEntities;
using BeezyTest.DomainEntities.Media;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeezyTest.DomainServices
{
	public interface IMovieSearchService
	{
		public Task<IList<Movie>> GetMoviesByCriteria(SearchCriteria criteria);
		public Task<Movie> GetMovieByTitle(string movie);
	}
}
