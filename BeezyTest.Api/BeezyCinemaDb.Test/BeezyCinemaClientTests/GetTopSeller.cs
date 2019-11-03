using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using BeezyTest.BeezyCinemaDb.Models;
using BeezyTest.BeezyCinemaDb.Models.BeezyCinema;

namespace BeezyTest.BeezyCinemaDb.Test.BeezyCinemaClientTests
{
	class GetTopSeller
	{
		private DbContextOptions<BeezyCinemaContext> DbContextOptions;
		private BeezyCinemaClient TestObject;

		[OneTimeSetUp]
		public void SetupData()
		{
			DbContextOptions = new DbContextOptionsBuilder<BeezyCinemaContext>()
				.UseInMemoryDatabase(databaseName: "GetTopSeller")
				.Options;
			LoadTestData(new BeezyCinemaContext(DbContextOptions));
		}
		[SetUp]
		public void Setup()
		{
			TestObject = new BeezyCinemaClient(new BeezyCinemaContext(DbContextOptions));
		}
		private void LoadTestData(BeezyCinemaContext context)
		{
			context.City.Add(new City { Id = 1, Name = "London", Population = 10000000 });
			context.City.Add(new City { Id = 2, Name = "Barcelona", Population = 5000000 });
			context.City.Add(new City { Id = 3, Name = "Brussels", Population = 1000000 });

			context.Cinema.Add(new Cinema { Id = 1, Name = "Cinema L One", CityId = 1 });
			context.Cinema.Add(new Cinema { Id = 2, Name = "Cinema L Two", CityId = 1 });
			context.Cinema.Add(new Cinema { Id = 3, Name = "Cinema L Three", CityId = 1 });
			context.Cinema.Add(new Cinema { Id = 11, Name = "Cinema Ba One", CityId = 2 });
			context.Cinema.Add(new Cinema { Id = 12, Name = "Cinema Ba Two", CityId = 2 });
			context.Cinema.Add(new Cinema { Id = 13, Name = "Cinema Ba Three", CityId = 2 });
			context.Cinema.Add(new Cinema { Id = 21, Name = "Cinema Br One", CityId = 3 });
			context.Cinema.Add(new Cinema { Id = 22, Name = "Cinema Br Two", CityId = 3 });
			context.Cinema.Add(new Cinema { Id = 23, Name = "Cinema Br Three", CityId = 3 });

			context.Room.Add(new Room { Id = 1, Name = "Room A1", CinemaId = 1, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 2, Name = "Room B1", CinemaId = 1, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 3, Name = "Room C1", CinemaId = 1, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 4, Name = "Room A2", CinemaId = 2, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 5, Name = "Room B2", CinemaId = 2, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 6, Name = "Room C2", CinemaId = 2, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 7, Name = "Room A3", CinemaId = 3, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 8, Name = "Room B3", CinemaId = 3, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 9, Name = "Room C3", CinemaId = 3, Seats = 100, Size = "small" });

			context.Room.Add(new Room { Id = 11, Name = "Room A1", CinemaId = 11, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 12, Name = "Room B1", CinemaId = 11, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 13, Name = "Room C1", CinemaId = 11, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 14, Name = "Room A2", CinemaId = 12, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 15, Name = "Room B2", CinemaId = 12, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 16, Name = "Room C2", CinemaId = 12, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 17, Name = "Room A3", CinemaId = 13, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 18, Name = "Room B3", CinemaId = 13, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 19, Name = "Room C3", CinemaId = 13, Seats = 100, Size = "small" });

			context.Room.Add(new Room { Id = 21, Name = "Room A1", CinemaId = 21, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 22, Name = "Room B1", CinemaId = 21, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 23, Name = "Room C1", CinemaId = 21, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 24, Name = "Room A2", CinemaId = 22, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 25, Name = "Room B2", CinemaId = 22, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 26, Name = "Room C2", CinemaId = 22, Seats = 100, Size = "small" });
			context.Room.Add(new Room { Id = 27, Name = "Room A3", CinemaId = 23, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 28, Name = "Room B3", CinemaId = 23, Seats = 1000, Size = "big" });
			context.Room.Add(new Room { Id = 29, Name = "Room C3", CinemaId = 23, Seats = 100, Size = "small" });

			context.Genre.Add(new Genre { Id = 1, Name = "Genre One" });
			context.Genre.Add(new Genre { Id = 2, Name = "Genre Two" });
			context.Genre.Add(new Genre { Id = 3, Name = "Genre Three" });
			context.Genre.Add(new Genre { Id = 4, Name = "Genre Four" });

			context.Movie.Add(new Movie { Id = 1, ReleaseDate = new DateTime(2018, 01, 01), OriginalTitle = "Movie One", OriginalLanguage = "en-US", Adult = false });
			context.Movie.Add(new Movie { Id = 2, ReleaseDate = new DateTime(2018, 02, 02), OriginalTitle = "Movie Two", OriginalLanguage = "en-US", Adult = false });
			context.Movie.Add(new Movie { Id = 3, ReleaseDate = new DateTime(2018, 03, 03), OriginalTitle = "Movie Three", OriginalLanguage = "en-US", Adult = false });
			context.Movie.Add(new Movie { Id = 4, ReleaseDate = new DateTime(2018, 04, 04), OriginalTitle = "Movie Four", OriginalLanguage = "en-US", Adult = false });
			context.Movie.Add(new Movie { Id = 5, ReleaseDate = new DateTime(2018, 05, 05), OriginalTitle = "Movie Five", OriginalLanguage = "en-US", Adult = false });

			context.MovieGenre.Add(new MovieGenre { MovieId = 1, GenreId = 1 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 1, GenreId = 2 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 2, GenreId = 1 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 2, GenreId = 2 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 3, GenreId = 2 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 3, GenreId = 3 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 3, GenreId = 4 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 4, GenreId = 3 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 4, GenreId = 4 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 5, GenreId = 3 });
			context.MovieGenre.Add(new MovieGenre { MovieId = 5, GenreId = 4 });

			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 1, MovieId = 1, RoomId = 1, SeatsSold = 800 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 2, MovieId = 1, RoomId = 4, SeatsSold = 800 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 3, MovieId = 1, RoomId = 7, SeatsSold = 800 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 4, MovieId = 1, RoomId = 11, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 5, MovieId = 1, RoomId = 14, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 6, MovieId = 1, RoomId = 17, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 7, MovieId = 1, RoomId = 21, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 8, MovieId = 1, RoomId = 24, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 9, MovieId = 1, RoomId = 27, SeatsSold = 200 });

			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 11, MovieId = 2, RoomId = 2, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 12, MovieId = 2, RoomId = 5, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 13, MovieId = 2, RoomId = 8, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 14, MovieId = 2, RoomId = 12, SeatsSold = 700 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 15, MovieId = 2, RoomId = 15, SeatsSold = 700 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 16, MovieId = 2, RoomId = 18, SeatsSold = 700 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 17, MovieId = 2, RoomId = 22, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 18, MovieId = 2, RoomId = 25, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 19, MovieId = 2, RoomId = 28, SeatsSold = 200 });

			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 21, MovieId = 3, RoomId = 3, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 22, MovieId = 3, RoomId = 6, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 23, MovieId = 3, RoomId = 9, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 24, MovieId = 3, RoomId = 13, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 25, MovieId = 3, RoomId = 16, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 26, MovieId = 3, RoomId = 19, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 27, MovieId = 3, RoomId = 23, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 28, MovieId = 3, RoomId = 26, SeatsSold = 90 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 29, MovieId = 3, RoomId = 29, SeatsSold = 90 });

			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 31, MovieId = 4, RoomId = 2, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 32, MovieId = 4, RoomId = 5, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 33, MovieId = 4, RoomId = 8, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 34, MovieId = 4, RoomId = 12, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 35, MovieId = 4, RoomId = 15, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 36, MovieId = 4, RoomId = 18, SeatsSold = 200 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 37, MovieId = 4, RoomId = 22, SeatsSold = 500 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 38, MovieId = 4, RoomId = 25, SeatsSold = 500 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 39, MovieId = 4, RoomId = 28, SeatsSold = 500 });

			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 41, MovieId = 5, RoomId = 3, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 42, MovieId = 5, RoomId = 6, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 43, MovieId = 5, RoomId = 9, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 44, MovieId = 5, RoomId = 13, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 45, MovieId = 5, RoomId = 16, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 46, MovieId = 5, RoomId = 19, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 47, MovieId = 5, RoomId = 23, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 48, MovieId = 5, RoomId = 26, SeatsSold = 75 });
			context.Session.Add(new BeezyTest.BeezyCinemaDb.Models.BeezyCinema.Session { Id = 49, MovieId = 5, RoomId = 29, SeatsSold = 75 });
			context.SaveChanges();
		}
		[Test]
		public async Task TestOne()
		{
			Assert.AreEqual("Movie One", await TestObject.GetTopSeller(1));
		}
		[Test]
		public async Task TestTwo()
		{
			Assert.AreEqual("Movie Two", await TestObject.GetTopSeller(2));
		}
		[Test]
		public async Task TestThree()
		{
			Assert.AreEqual("Movie Four", await TestObject.GetTopSeller(3));
		}
	}
}
