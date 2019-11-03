using BeezyTest.DomainEntities.Media;
using BeezyTest.DomainServices.Billboards;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeezyTest.DomainServices.Test.Billboards.BillboardGeneratorTests
{
	public class Generate
	{
		private BillboardGenerator TestObject;

		private readonly Movie movie1 = new Movie { Title = "Movie One",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,01,01), WebSite = "https://www.one.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie one is a movie about one" };
		private readonly Movie movie2 = new Movie { Title = "Movie Two",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,02,02), WebSite = "https://www.two.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie two is a movie about two"};
		private readonly Movie movie3 = new Movie { Title = "Movie Three",   Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,03,03), WebSite = "https://www.three.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie three is a movie about three"};
		private readonly Movie movie4 = new Movie { Title = "Movie Four",    Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,04,04), WebSite = "https://www.four.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie four is a movie about four"};
		private readonly Movie movie5 = new Movie { Title = "Movie Five",    Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,05,05), WebSite = "https://www.five.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie five is a movie about five"};
		private readonly Movie movie6 = new Movie { Title = "Movie Six",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2018,06,06), WebSite = "https://www.six.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie six is a movie about six"};
		private readonly Movie movie7 = new Movie { Title = "Movie Seven",   Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,07,07), WebSite = "https://www.seven.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie seven is a movie about seven"};
		private readonly Movie movie8 = new Movie { Title = "Movie Eight",   Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,08,08), WebSite = "https://www.eight.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie eight is a movie about eight"};
		private readonly Movie movie9 = new Movie { Title = "Movie Nine",    Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,09,09), WebSite = "https://www.nine.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie nine is a movie about nine"};
		private readonly Movie movie10 = new Movie { Title = "Movie Ten",    Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,10,10), WebSite = "https://www.ten.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie ten is a movie about ten"};
		private readonly Movie movie11 = new Movie { Title = "Movie Eleven", Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,11,11), WebSite = "https://www.eleven.mov", Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie eleven is a movie about eleven"};
		private readonly Movie movie12 = new Movie { Title = "Movie Twelve", Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,12,12), WebSite = "https://www.twelve.mov", Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie twelve is a movie about twelve"};
		private readonly Movie movie13 = new Movie { Title = "Movie Thirteen",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,01,01), WebSite = "https://www.one.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie one is a movie about one"};
		private readonly Movie movie14 = new Movie { Title = "Movie Fourteen",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,02,02), WebSite = "https://www.two.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie two is a movie about two"};
		private readonly Movie movie15 = new Movie { Title = "Movie Fifteen",      Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,03,03), WebSite = "https://www.three.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie three is a movie about three"};
		private readonly Movie movie16 = new Movie { Title = "Movie Sixteen",      Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,04,04), WebSite = "https://www.four.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie four is a movie about four"};
		private readonly Movie movie17 = new Movie { Title = "Movie Seventeen",    Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,05,05), WebSite = "https://www.five.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie five is a movie about five"};
		private readonly Movie movie18 = new Movie { Title = "Movie Eighteen",     Genres = new List<string> { "Blockbustergenre" }, ReleaseDate = new DateTime(2019,06,06), WebSite = "https://www.six.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie six is a movie about six"};
		private readonly Movie movie19 = new Movie { Title = "Movie Nineteen",     Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2019,07,07), WebSite = "https://www.seven.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie seven is a movie about seven"};
		private readonly Movie movie20 = new Movie { Title = "Movie Twenty",       Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2019,08,08), WebSite = "https://www.eight.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie eight is a movie about eight"};
		private readonly Movie movie21 = new Movie { Title = "Movie Twenty one",   Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2019,09,09), WebSite = "https://www.nine.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie nine is a movie about nine"};
		private readonly Movie movie22 = new Movie { Title = "Movie Twenty two",   Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2019,10,10), WebSite = "https://www.ten.mov",    Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie ten is a movie about ten"};
		private readonly Movie movie23 = new Movie { Title = "Movie Twenty three", Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2019,11,11), WebSite = "https://www.eleven.mov", Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie eleven is a movie about eleven"};
		private readonly Movie movie24 = new Movie { Title = "Movie Twelve four",  Genres = new List<string> { "NA" }, ReleaseDate = new DateTime(2018,12,12), WebSite = "https://www.twelve.mov", Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie twelve is a movie about twelve"};
		public bool StubRuleAlwaysTrue(Movie movie) => true;
		public bool StubRuleAlwaysFalse(Movie movie) => false;
		public bool StubRuleCheckGenre(Movie movie) => (movie.Genres.FirstOrDefault() == "Blockbustergenre");

		private IList<Movie> movieList;

		[SetUp]
		public void Setup()
		{
			TestObject = new BillboardGenerator();
			movieList = new List<Movie> { 
				movie1, movie2, movie3, movie4, movie5, movie6, movie7, movie8, movie9, movie10, movie11, movie12,
				movie13, movie14, movie15, movie16, movie17, movie18, movie19, movie20, movie21, movie22, movie23, movie24
			};
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}

		[Test]
		public void TestNoMovies()
		{
			Assert.Throws<InsufficientItemsException>(() =>TestObject.Generate(new List<Movie>(), 1, 2, 2, StubRuleCheckGenre));
		}
		
		[Test]
		public void TestInsufficientSmallMovies()
		{
			Assert.Throws<InsufficientItemsException>(() => TestObject.Generate(movieList, 1, 2, 2, StubRuleAlwaysTrue));
		}
		[Test]
		public void TestInsufficientBigMovies()
		{
			Assert.Throws<InsufficientItemsException>(() => TestObject.Generate(movieList, 1, 2, 2, StubRuleAlwaysFalse));
		}
		[Test]
		public void TestOnlyBigMScreens()
		{
			var result = TestObject.Generate(movieList, 1, 2, 0, StubRuleCheckGenre);
			Assert.AreEqual(1, result.Schedule.Length, "There should be 1 week scheduled");
			Assert.AreEqual(2, result.Schedule[0].BigScreens.Length, "All 2 big screens should have movies scheduled");
			Assert.AreEqual(0, result.Schedule[0].SmallScreens.Length, "There should be no entry for small screens");
		}
		[Test]
		public void TestOnlySmallScreens()
		{
			var result = TestObject.Generate(movieList, 1, 0, 2, StubRuleCheckGenre);
			Assert.AreEqual(1, result.Schedule.Length, "There should be 1 week scheduled");
			Assert.AreEqual(0, result.Schedule[0].BigScreens.Length, "There should be no entry for big screens");
			Assert.AreEqual(2, result.Schedule[0].SmallScreens.Length, "All 2 small screens should have movies scheduled");
		}
		[Test]
		public void TestOneWeekSchedule()
		{
			var result = TestObject.Generate(movieList, 1, 2, 2, StubRuleCheckGenre);
			Assert.AreEqual(1, result.Schedule.Length, "There should be 1 week scheduled");
			Assert.AreEqual(2, result.Schedule[0].BigScreens.Length, "All 2 big screens should have movies scheduled");
			Assert.AreEqual(2, result.Schedule[0].SmallScreens.Length, "All 2 small screens should have movies scheduled");
		}
		[Test]
		public void TestMultipleWeeksSchedule()
		{
			var result = TestObject.Generate(movieList, 3, 2, 2, StubRuleCheckGenre);
			Assert.AreEqual(3, result.Schedule.Length, "There should be 3 weeks scheduled");
			Assert.AreEqual(2, result.Schedule[0].BigScreens.Length, "All 2 big screens should have movies scheduled on week 1");
			Assert.AreEqual(2, result.Schedule[0].SmallScreens.Length, "All 2 small screens should have movies scheduled on week 1");
			Assert.AreEqual(2, result.Schedule[1].BigScreens.Length, "All 2 big screens should have movies scheduled on week 3");
			Assert.AreEqual(2, result.Schedule[1].SmallScreens.Length, "All 2 small screens should have movies scheduled on week 3");
			Assert.AreEqual(2, result.Schedule[2].BigScreens.Length, "All 2 big screens should have movies scheduled on week 3");
			Assert.AreEqual(2, result.Schedule[2].SmallScreens.Length, "All 2 small screens should have movies scheduled on week 3");
		}
		
	}
}