using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.Actions;
using BeezyTest.TmdbServices.Config;

namespace BeezyTest.TmdbServices.Test.Actions.DiscoverMovieActionTests
{
	class RequestParameters
	{
		private DiscoverMovieAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new DiscoverMovieAction();
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}

		[Test]
		public void TestNone()
		{
			Assert.AreEqual("", TestObject.RequestParameters.ToString());
		}

		[Test]
		public void TestMinDate()
		{
			TestObject.SetMinDate(new DateTime(2010, 4, 5));
			Assert.AreEqual("primary_release_date.gte=2010-4-5", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestMaxDate()
		{
			TestObject.SetMaxDate(new DateTime(2011, 2, 3));
			Assert.AreEqual("primary_release_date.lte=2011-2-3", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestKeywords()
		{
			TestObject.SetKeywords(new List<int> { 7, 8, 9 });
			Assert.AreEqual("with_keywords=7,8,9", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestGenres()
		{
			TestObject.SetGenres(new List<int> { 11, 22, 33 });
			Assert.AreEqual("with_genres=11|22|33", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestReleaseTypes()
		{
			TestObject.SetReleaseTypes(new List<int>{10, 20});
			Assert.AreEqual("with_release_types=10,20", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestAll()
		{
			var config = new TmdbConfig();
			TestObject.SetMinDate(new DateTime(2010, 2, 3))
				.SetMaxDate(new DateTime(2011, 4, 5))
				.SetKeywords(new List<int> { 7,8,9 })
				.SetGenres(new List<int>{11,22,33})
				.SetReleaseTypes(new List<int>{10, 20});
			Assert.AreEqual("with_keywords=7,8,9&with_genres=11|22|33&with_release_types=10,20&primary_release_date.gte=2010-2-3&primary_release_date.lte=2011-4-5", TestObject.RequestParameters.ToString());
		}
	}
}
