using NUnit.Framework;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Actions.DiscoverMovieActionTests
{
	public class Url
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
		public void Test()
		{
			var config = new TmdbConfig();
			Assert.AreEqual("/3/discover/movie", TestObject.Url(config));
		}
	}
}