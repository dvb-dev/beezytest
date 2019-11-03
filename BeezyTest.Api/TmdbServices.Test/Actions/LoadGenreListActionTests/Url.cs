using NUnit.Framework;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.LoadGenreListActionTests
{
	public class Url
	{
		private LoadGenreListAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new LoadGenreListAction();
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
			Assert.AreEqual("/3/genre/movie/list", TestObject.Url(config));
		}
	}
}
