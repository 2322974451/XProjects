using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class ObjectPoolCache
	{

		public static void Clear()
		{
			ObjectPoolCache.s_AllPool.Clear();
		}

		public static readonly List<IObjectPool> s_AllPool = new List<IObjectPool>();
	}
}
