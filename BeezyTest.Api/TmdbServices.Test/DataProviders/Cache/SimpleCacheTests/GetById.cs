using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.DataProviders.Cache;

namespace BeezyTest.TmdbServices.Test.DataProviders.Cache.SimpleCacheTests
{
	class GetById
	{
		class StorageItem : IIdNamePair
		{
			public int id { get; set; }

			public string name { get; set; }
		}
		private SimpleCache<StorageItem> TestObject;
		[SetUp]
		public void SetUp()
		{
			TestObject = new SimpleCache<StorageItem>();
			TestObject.StoreItems(new List<StorageItem>
			{
				new StorageItem {id = 1, name = "One"},
				new StorageItem {id = 2, name = "Two"},
				new StorageItem {id = 3, name = "Three"}
			});
		}
		[TearDown]
		public void TearDown()
		{
			TestObject = null;
		}
		[Test]
		public void Test()
		{
			Assert.AreEqual("One", TestObject.GetById(1).name);
			Assert.AreEqual("Two", TestObject.GetById(2).name);
			Assert.AreEqual("Three", TestObject.GetById(3).name);
		}
		[Test]
		public void TestNotFound()
		{
			Assert.AreEqual(null, TestObject.GetById(4));
		}
	}
}
