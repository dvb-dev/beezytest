using BeezyTest.DomainEntities;
using BeezyTest.DomainEntities.Media;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeezyTest.DomainServices.Recommendations
{
	public class RecommendationListBuilder
	{
		private IMovieSearchService _MovieSearchService;
		public RecommendationListBuilder(IMovieSearchService discoveryService)
		{
			_MovieSearchService = discoveryService;
		}
		public async Task<IList<Movie>> BuildList(IList<SearchCriteria> criterias)
		{
			List<Movie> result = new List<Movie>();
			foreach(var criteria in criterias)
			{
				result.AddRange(await _MovieSearchService.GetMoviesByCriteria(criteria));
			}
			return result;
		}
	}
}
