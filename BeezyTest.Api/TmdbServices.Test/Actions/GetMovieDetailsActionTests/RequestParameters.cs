using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.Actions;

namespace BeezyTest.TmdbServices.Test.Actions.GetMovieDetailsActionTests
{
	class RequestParameters
	{
		private GetMovieDetailsAction TestObject;

		[SetUp]
		public void Setup()
		{
			TestObject = new GetMovieDetailsAction(0);
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
		public void TestLanguage()
		{
			TestObject.SetLanguage("es-ES");
			Assert.AreEqual("language=es-ES", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestAppendRequest()
		{
			TestObject.AppendRequest(GetMovieDetailsAction.AppendedRequest.keywords);
			Assert.AreEqual("append_to_response=keywords", TestObject.RequestParameters.ToString());
		}
		[Test]
		public void TestAll()
		{
			TestObject.SetLanguage("es-ES")
				.AppendRequest(GetMovieDetailsAction.AppendedRequest.keywords);
			Assert.AreEqual("language=es-ES&append_to_response=keywords", TestObject.RequestParameters.ToString());
		}
	}
}
