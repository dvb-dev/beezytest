using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.LoadGenreListActionTests
{
	class RequestParameters
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
		public void TestNone()
		{
			Assert.AreEqual("", TestObject.RequestParameters.ToString());
		}
	}
}
