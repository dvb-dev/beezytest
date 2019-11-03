using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.TmdbServices.Config
{
	/// <summary>
	/// Configuration information for accessing the TMDb API
	/// This class is simply a stub for now, created for demonstration purposes only.
	/// </summary>
	public class TmdbConfig 
	{
		const string base_url = "https://api.themoviedb.org";
		const string url_get_movie = "/3/movie";
		const string url_discover_movie = "/3/discover/movie";
		const string url_search_movie = "/3/search/movie";
		const string url_search_keyword = "/3/search/keyword";
		const string url_list_genres = "/3/genre/movie/list";

		public string ApiKey { get; set; }
		public string ReadAccessToken { get; set; }
		public string BaseUrl { get => base_url; }
		public string UrlGetMovie { get => url_get_movie;  }
		public string UrlDiscoverMovie { get => url_discover_movie;  }
		public string UrlSearchMovie { get => url_search_movie;  }
		public string UrlSearchKeyword { get => url_search_keyword;  }
		public string UrlListGenres { get => url_list_genres;  }


	}
}
