using System;
using System.Threading.Tasks;
using BeezyTest.Api.Dto.Cinema.Billboard;
using BeezyTest.Api.Dto.Result;
using BeezyTest.Api.Dto.Result.Cinema.Billboard;
using BeezyTest.DomainServices;
using BeezyTest.DomainServices.Billboards;
using BeezyTest.DomainServices.Recommendations;
using BeezyTest.DomainServices.Rules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeezyTest.Api.Controllers.Cinema
{
	[Produces("application/json")]  //Keeping it simple for now, forcing JSON
    [Route("cinema/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
		protected IMovieSearchService MovieSearchService { get; }
		protected IBoxOfficeService BoxOfficeService { get; }
		public BillboardController(IMovieSearchService movieSearchSvc, IBoxOfficeService boxOfficeSvc)
		{
			MovieSearchService = movieSearchSvc;
			BoxOfficeService = boxOfficeSvc;
		}
		[HttpGet("BuildSimple")]
		public IActionResult BuildSimple([FromQuery] BuildSimpleDto parameters)
		{
			throw new NotImplementedException();
		}
		[HttpGet("BuildAdvanced")]
		public async Task<IActionResult> BuildAdvanced([FromQuery] BuildAdvancedDto parameters)
		{
			if (ModelState.IsValid)
			{
				try
				{
					RecommendationListBuilder builder = new RecommendationListBuilder(MovieSearchService);
					BillboardGenerator generator = new BillboardGenerator();
					BlockBusterRule rule = new BlockBusterRule();

					var criteria = await GetCriteriaBuilder(parameters).CompileCriteria();
					var list = await builder.BuildList(criteria);
					var result = generator.Generate(list, parameters.weekCount.Value, parameters.bigScreenCount, parameters.smallScreenCount, rule.IsBlockBusterGenre);
					return Ok(new AdvancedBillboardResult { Billboard = result });
				}
				catch(InsufficientItemsException generatorErr)
				{
					ErrorResult errorObj = new ErrorResult { status_message = generatorErr.Message };
					return StatusCode(StatusCodes.Status400BadRequest, errorObj);
				}
				catch(NotImplementedException notImplementedErr)
				{
					ErrorResult errorObj = new ErrorResult { status_message = notImplementedErr.Message };
					return StatusCode(StatusCodes.Status501NotImplemented, errorObj);
				}
				catch(Exception e)
				{
					ErrorResult errorObj = new ErrorResult { status_message = e.Message };
					return StatusCode(StatusCodes.Status500InternalServerError, errorObj);
				}
			}
			else
			{
				return NotFound();
			}
		}
		private CriteriaBuilder GetCriteriaBuilder(BuildAdvancedDto parameters)
		{
			CriteriaBuilder builder = new CriteriaBuilder(BoxOfficeService, MovieSearchService);
			builder.CityId = parameters.cityId.Value;
			builder.Keywords = parameters.keywords;
			builder.Genres = parameters.genres;
			builder.UpcomingOnly = parameters.upcomingOnly;
			builder.UseBoxOfficeData = parameters.useBoxOfficeData;
			return builder;
		}
    }
}