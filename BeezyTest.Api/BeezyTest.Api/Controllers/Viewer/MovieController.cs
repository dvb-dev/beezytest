using System;
using BeezyTest.Api.Dto.Viewer.Movie;
using Microsoft.AspNetCore.Mvc;

namespace BeezyTest.Api.Controllers.Viewer
{
    [Route("viewer/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
		[HttpGet("Recommend")]
		public IActionResult Recommend([FromQuery] RecommendDto requestParaneters)
		{
			throw new NotImplementedException();
		}
    }
}