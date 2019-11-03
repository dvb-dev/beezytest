using System;
using BeezyTest.Api.Dto.Viewer.Documentary;
using Microsoft.AspNetCore.Mvc;

namespace BeezyTest.Api.Controllers.Viewer
{
    [Route("viewer/[controller]")]
    [ApiController]
    public class DocumentaryController : ControllerBase
    {
		[HttpGet("Recommend")]
		public IActionResult Recommend([FromQuery]RecommendDto requestParameters)
		{
			throw new NotImplementedException();
		}
    }
}