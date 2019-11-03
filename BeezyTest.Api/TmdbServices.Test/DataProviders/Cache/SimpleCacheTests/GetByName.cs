using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BeezyTest.TmdbServices.DataProviders.Cache;

namespace BeezyTest.TmdbServices.Test.DataProviders.Cache.SimpleCacheTests
{
	public class GetByName
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
			Assert.AreEqual(1, TestObject.GetByName("One").id);
			Assert.AreEqual(2, TestObject.GetByName("Two").id);
			Assert.AreEqual(3, TestObject.GetByName("Three").id);
		}
		[Test]
		public void TestNotFound()
		{
			Assert.AreEqual(null, TestObject.GetByName("Four"));
		}
	}
}
