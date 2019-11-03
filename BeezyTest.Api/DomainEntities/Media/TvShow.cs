using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.DomainEntities.Media
{
	public class TvShow
	{
	public string Title { get; set; }
	public string Overview { get; set; }
	public IList<string> Genres { get; set; }
	public string Language { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string WebSite { get; set; }
	public IList<string> Keywords { get; set; }
	public int SeasonCount { get; set; }
	public int EpisodeCount { get; set; }
	public bool HasConcluded { get; set; }
	}
}
