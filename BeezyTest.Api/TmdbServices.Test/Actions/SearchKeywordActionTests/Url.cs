using NUnit.Framework;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.SearchKeywordActionTests
{
	public class Url
	{
		private SearchKeywordAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new SearchKeywordAction("dummyValue");
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
			Assert.AreEqual("/3/search/keyword", TestObject.Url(config));
		}
	}
}
