using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000192 RID: 402
	public class ObjectPoolCache
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x0002EF9F File Offset: 0x0002D19F
		public static void Clear()
		{
			ObjectPoolCache.s_AllPool.Clear();
		}

		// Token: 0x040003F8 RID: 1016
		public static readonly List<IObjectPool> s_AllPool = new List<IObjectPool>();
	}
}
