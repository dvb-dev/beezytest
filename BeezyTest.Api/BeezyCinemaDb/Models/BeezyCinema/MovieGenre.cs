
namespace BeezyTest.BeezyCinemaDb.Models.BeezyCinema
{
    public partial class MovieGenre
    {
        public int MovieId { get; set; }
		public Movie Movie { get; set; }
        public int GenreId { get; set; }
		public Genre Genre { get; set; }
    }
}
