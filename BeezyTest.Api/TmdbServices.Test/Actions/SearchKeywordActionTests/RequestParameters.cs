using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.SearchKeywordActionTests
{
	class RequestParameters
	{
		private SearchMovieAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new SearchMovieAction("testValue");
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}

		[Test]
		public void TestNone()
		{
			Assert.AreEqual("query=testValue", TestObject.RequestParameters.ToString());
		}
	}
}
