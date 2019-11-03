using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.DomainEntities.Media
{
	public class Movie
	{
	public string Title { get; set; }
	public string Overview { get; set; }
	public IEnumerable<string> Genres { get; set; }
	public string Language { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string WebSite { get; set; }
	public IEnumerable<string> Keywords { get; set; }
	}
}
