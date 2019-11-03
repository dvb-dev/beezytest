using NUnit.Framework;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.SearchMovieActionTests
{
	public class Url
	{
		private SearchMovieAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new SearchMovieAction("dummyValue");
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}

		[Test]
		public void Test()
		{
			var config = new TmdbConfig();
			Assert.AreEqual("/3/search/movie", TestObject.Url(config));
		}
	}
}
