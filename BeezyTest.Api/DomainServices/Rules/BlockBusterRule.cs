using BeezyTest.DomainEntities.Media;
using System.Collections.Generic;
using System.Linq;

namespace BeezyTest.DomainServices.Rules
{
	public class BlockBusterRule
	{
		/// <summary>
		///  List of (lower cased) genres which are considered "Block buster genres"
		///  This is hard-coded here for simplicity.
		/// </summary>
		public IList<string> BlockBusterGenres {
			get => new List<string> { "action", "adventure" };
		}
		public bool IsBlockBusterGenre(Movie movie)
		{
			/*
			foreach (var genre in movie.Genres)
			{
				if (BlockBusterGenres.Contains(genre.ToLower()))
				{
					return true;
				}
			}
			return false;*/
			foreach (var genre in BlockBusterGenres)
			{
				var selection = movie.Genres.FirstOrDefault(x => x.ToLower() == genre);
				if (selection == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
