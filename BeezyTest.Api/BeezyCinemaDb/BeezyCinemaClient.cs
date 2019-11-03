using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BeezyTest.BeezyCinemaDb.Models.BeezyCinema;
using BeezyTest.BeezyCinemaDb.Models;
using BeezyTest.DomainServices;
using System.Collections.Generic;

namespace BeezyTest.BeezyCinemaDb
{
	public class BeezyCinemaClient : IBoxOfficeService
	{
		private readonly BeezyCinemaContext _Context;
		public BeezyCinemaClient(BeezyCinemaContext context)
		{
			_Context = context;
		}
		public async Task<string> GetTopSeller(int cityId)
		{
			// only look for rooms in cinemas of the given city
			var cityRoomIds = (from room in _Context.Room
							   join cinema in _Context.Cinema on room.CinemaId equals cinema.Id
							   where cinema.CityId == cityId
							   select room.Id);
			// find all movie sessions in those rooms
			var sessionList = (from session in _Context.Session
							   where cityRoomIds.Contains(session.RoomId)
							   select session);
			// calculate the total seats sold for each movie across the city
			// and sort descending
			var highestGrossingMovie = sessionList.GroupBy(s => s.MovieId).Select(r => new
	{
				MovieId = r.Key,
				TotalSold = r.Sum(s => s.SeatsSold)
			}).OrderByDescending(r => r.TotalSold);

			// retrieve the title of the movies
			var movieQuery = (from entry in highestGrossingMovie
							  join movie in _Context.Movie on entry.MovieId equals movie.Id
							  select movie.OriginalTitle);
				
			// return the first one (if any)
			var data = await movieQuery.FirstOrDefaultAsync();
			return data;

		}
		public async Task<string> GetTopSellerByGenre(int cityId, string genreName)
		{
			// JIBBED for now, this really should be separated out
			var genres = await GetGenreIds(genreName.ToLower());
			if (genres.Count == 0)
			{
				return "";
			}
			var genreId = genres[0];
			// End JIB

			// only look for rooms in cinemas of the given city
			var cityRoomIds = (from room in _Context.Room
							   join cinema in _Context.Cinema on room.CinemaId equals cinema.Id
							   where cinema.CityId == cityId
							   select room.Id);
			// find all movie sessions in those rooms
			var sessionList = (from session in _Context.Session
							   where cityRoomIds.Contains(session.RoomId)
							   select session);
			var filteredSessionList = (from session in sessionList
									   join movieGenre in _Context.MovieGenre on session.MovieId equals movieGenre.MovieId
									   where movieGenre.GenreId == genreId
									   select session);
			// calculate the total seats sold for each movie across the city
			// and sort descending
			var highestGrossingMovie = filteredSessionList.GroupBy(s => s.MovieId).Select(r => new
	{
				MovieId = r.Key,
				TotalSold = r.Sum(s => s.SeatsSold)
			}).OrderByDescending(r => r.TotalSold);

			// retrieve the title of the movies
			var movieQuery = (from entry in highestGrossingMovie
							  join movie in _Context.Movie on entry.MovieId equals movie.Id
							  select movie.OriginalTitle);
				
			// return the first one (if any)
			var data = await movieQuery.FirstOrDefaultAsync();
			return data;
		}
		private async Task<IList<int>> GetGenreIds(string name)
		{
			var genreQuery = (from genre in _Context.Genre
							  where genre.Name.ToLower() == name
							  select genre.Id);
			return await genreQuery.ToListAsync();
		}
	}
}
