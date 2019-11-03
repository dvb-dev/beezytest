using BeezyTest.DomainEntities.Media;
using BeezyTest.DomainServices.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BeezyTest.DomainServices.Test.Rules.BlockBusterRuleTests
{
	class IsBlockBusterGenre
	{
		private readonly Movie movieSimple = new Movie { Title = "Movie One",          Genres = new List<string> { "Action" },                    ReleaseDate = new DateTime(2018,01,01), WebSite = "https://www.one.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie one is a movie about one" };
		private readonly Movie movieMultiple = new Movie { Title = "Movie Two",        Genres = new List<string> { "Action", "Adventure" },       ReleaseDate = new DateTime(2018,02,02), WebSite = "https://www.two.mov",   Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie two is a movie about two"};
		private readonly Movie movieEmpty = new Movie { Title = "Movie Three",         Genres = new List<string> (),                              ReleaseDate = new DateTime(2018,03,03), WebSite = "https://www.three.mov", Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie three is a movie about three"};
		private readonly Movie movieMixed = new Movie { Title = "Movie Four",          Genres = new List<string> { "Adventure", "Comedy" }, ReleaseDate = new DateTime(2018,04,04), WebSite = "https://www.four.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie four is a movie about four"};
		private readonly Movie movieNotBlockBuster = new Movie { Title = "Movie Five", Genres = new List<string> { "Comedy", "Crime" },           ReleaseDate = new DateTime(2018,05,05), WebSite = "https://www.five.mov",  Keywords = new List<string> { "a", "b", "c" }, Language = "en-US", Overview = "Movie five is a movie about five"};

		private BlockBusterRule TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new BlockBusterRule();
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}
		/*[Test]
		public void TestSimple()
		{
			Assert.True(TestObject.IsBlockBusterGenre(movieSimple));
		}*/
		[Test]
		public void TestMultiple()
		{
			Assert.True(TestObject.IsBlockBusterGenre(movieMultiple));
		}
		[Test]
		public void TestMixed()
		{
			Assert.False(TestObject.IsBlockBusterGenre(movieMixed));
		}
		[Test]
		public void TestNoBluckbusters()
		{
			Assert.False(TestObject.IsBlockBusterGenre(movieNotBlockBuster));
		}

		[Test]
		public void TestEmpty()
		{
			Assert.False(TestObject.IsBlockBusterGenre(movieEmpty));
		}
	}
}
