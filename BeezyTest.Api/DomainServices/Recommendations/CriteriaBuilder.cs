using BeezyTest.DomainEntities;
using BeezyTest.DomainServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeezyTest.DomainServices.Recommendations
{
	public class CriteriaBuilder
	{
		private IBoxOfficeService _BoxOfficeProvider;
		private IMovieSearchService _MovieSearchProvider;
		public int CityId { get; set; }
		public bool UpcomingOnly { get; set; }
		public bool UseBoxOfficeData { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IList<string> Genres { get; set; }
		public IList<string> Keywords { get; set; }
		public CriteriaBuilder(IBoxOfficeService boxOfficeProvider, IMovieSearchService movieSearchProvider)
		{
			_BoxOfficeProvider = boxOfficeProvider;
			_MovieSearchProvider = movieSearchProvider;
		}
		public async Task<IList<SearchCriteria>> CompileCriteria()
		{
			List<SearchCriteria> result = new List<SearchCriteria>();
			SearchCriteria baseCriteria = new SearchCriteria();
			baseCriteria.UpcomingOnly = UpcomingOnly;
			baseCriteria.StartDate = StartDate;
			baseCriteria.EndDate = EndDate;
			baseCriteria.Genres = (Genres == null) ? new List<string>() : new List<string>(Genres);
			baseCriteria.Keywords = (Keywords == null) ? new List<string>() : new List<string>(Keywords);
			if (UseBoxOfficeData)
			{
				List<string> successMovies = await GetBoxOfficeData(_BoxOfficeProvider, CityId, Genres);
				foreach (var movieTitle in successMovies)
				{
					var criteria = new SearchCriteria(baseCriteria);
					var movie = await _MovieSearchProvider.GetMovieByTitle(movieTitle);
					criteria.Genres.AddRange(new List<string>(movie.Genres.ToList().Take(2).Where(x => !criteria.Genres.Contains(x))));
					//OUT: Too stringint: criteria.Keywords.Add(movie.Keywords.ToList().First());
					result.Add(criteria);
				}
			}
			else
			{
				result.Add(baseCriteria);
			}
			return result;
		}
		private async Task<List<string>> GetBoxOfficeData(IBoxOfficeService provider, int cityId, IEnumerable<string> genres)
		{
			List<string> successMovies = new List<string>();

			if (genres == null)
			{
				var movieTitle = await provider.GetTopSeller(cityId);
				if (movieTitle != null)
				{
					successMovies.Add(movieTitle);
				}
			}
			else
			{
				foreach (var genre in Genres)
				{
					var movieTitle = await provider.GetTopSellerByGenre(cityId, genre);
					if (movieTitle != null)
					{
						successMovies.Add(movieTitle);
					}
				}
			}
			return successMovies;
		}
	}
}
