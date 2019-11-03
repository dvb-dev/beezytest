using System;
using System.Collections.Generic;

namespace BeezyTest.BeezyCinemaDb.Models.BeezyCinema
{
    public partial class Movie
    {
        public Movie()
        {
            Session = new HashSet<Session>();
			MovieGenre = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string OriginalLanguage { get; set; }
        public bool Adult { get; set; }

        public virtual ICollection<Session> Session { get; set; }
		public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
