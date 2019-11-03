using NUnit.Framework;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.GetMovieDetailsActionTests
{
	public class Url
	{
		private GetMovieDetailsAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new GetMovieDetailsAction(123);
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
			Assert.AreEqual("/3/movie/123", TestObject.Url(config));
		}
	}
}
