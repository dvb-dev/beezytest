using System;
using Microsoft.AspNetCore.Mvc;

namespace BeezyTest.Api.Controllers.Cinema
{
    [Route("cinema/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
		[HttpGet("Recommend")]
		public IActionResult Recommend(string ageRate, string period)
		{
			throw new NotImplementedException();
		}

	}
}