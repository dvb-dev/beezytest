using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.TmdbServices.DataProviders.Cache
{
	class SimpleCache<T>
		where T:IIdNamePair
	{
		private Dictionary<int, T> _IdIndex;
		private Dictionary<string, T> _NameIndex;
		public SimpleCache()
		{
			_IdIndex = new Dictionary<int, T>();
			_NameIndex = new Dictionary<string, T>();
		}
		public void StoreItems(IEnumerable<T> list)
		{
			foreach( var item in list)
			{
				_IdIndex[item.id] = item;
				_NameIndex[item.name.ToLower()] = item;
			}
		}
		public T GetById(int id)
		{
			if (_IdIndex.ContainsKey(id))
			{
				return _IdIndex[id];
			}
			else
			{
				return default(T);
			}
		}
		public T GetByName(string name)
		{
			name = name.ToLower();
			if (_NameIndex.ContainsKey(name))
			{
				return _NameIndex[name];
			}
			else
			{
				return default(T);
			}
		}
	}
}
