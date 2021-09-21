using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000194 RID: 404
	public class ListPool<T>
	{
		// Token: 0x060008C3 RID: 2243 RVA: 0x0002F0FC File Offset: 0x0002D2FC
		public static List<T> Create()
		{
			return new List<T>();
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0002F114 File Offset: 0x0002D314
		public static List<T> Get()
		{
			return ListPool<T>.s_Pool.Get();
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0002F130 File Offset: 0x0002D330
		public static void Release(List<T> toRelease)
		{
			ListPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x040003FE RID: 1022
		private static readonly ObjectPool<List<T>> s_Pool = new ObjectPool<List<T>>(new ObjectPool<List<T>>.CreateObj(ListPool<T>.Create), delegate(List<T> l)
		{
			l.Clear();
		}, delegate(List<T> l)
		{
			l.Clear();
		});
	}
}
