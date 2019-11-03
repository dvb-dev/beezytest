using System;
using BeezyTest.Api.Dto.Viewer.TvShow;
using Microsoft.AspNetCore.Mvc;

namespace BeezyTest.Api.Controllers.Viewer
{
    [Route("viewer/[controller]")]
    [ApiController]
    public class TvShowController : ControllerBase
    {
		[HttpGet("Recommend")]
		public IActionResult Recommend([FromQuery]RecommendDto requestParameters)
		{
			throw new NotImplementedException();
		}
    }
}