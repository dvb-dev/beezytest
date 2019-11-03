using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyTest.TmdbServices.DataProviders.Cache
{
	interface IIdNamePair
	{
		int id { get; }
		string name { get; }
	}
}
