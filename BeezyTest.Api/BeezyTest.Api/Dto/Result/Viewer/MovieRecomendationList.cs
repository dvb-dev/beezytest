using BeezyTest.DomainEntities.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeezyTest.Api.Dto.Result.Viewer
{
	public class MovieRecomendationList
	{
		public IList<Movie> movies;
	}
}
