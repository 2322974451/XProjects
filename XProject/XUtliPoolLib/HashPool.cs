using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000197 RID: 407
	public class HashPool<T>
	{
		// Token: 0x060008D2 RID: 2258 RVA: 0x0002F270 File Offset: 0x0002D470
		public static HashSet<T> Create()
		{
			return new HashSet<T>();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0002F288 File Offset: 0x0002D488
		public static HashSet<T> Get()
		{
			return HashPool<T>.s_Pool.Get();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0002F2A4 File Offset: 0x0002D4A4
		public static void Release(HashSet<T> toRelease)
		{
			HashPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x04000401 RID: 1025
		private static readonly ObjectPool<HashSet<T>> s_Pool = new ObjectPool<HashSet<T>>(new ObjectPool<HashSet<T>>.CreateObj(HashPool<T>.Create), delegate(HashSet<T> l)
		{
			l.Clear();
		}, delegate(HashSet<T> l)
		{
			l.Clear();
		});
	}
}
