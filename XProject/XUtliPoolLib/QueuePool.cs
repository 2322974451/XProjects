using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000196 RID: 406
	public class QueuePool<T>
	{
		// Token: 0x060008CD RID: 2253 RVA: 0x0002F1F4 File Offset: 0x0002D3F4
		public static Queue<T> Create()
		{
			return new Queue<T>();
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0002F20C File Offset: 0x0002D40C
		public static Queue<T> Get()
		{
			return QueuePool<T>.s_Pool.Get();
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0002F228 File Offset: 0x0002D428
		public static void Release(Queue<T> toRelease)
		{
			QueuePool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x04000400 RID: 1024
		private static readonly ObjectPool<Queue<T>> s_Pool = new ObjectPool<Queue<T>>(new ObjectPool<Queue<T>>.CreateObj(QueuePool<T>.Create), delegate(Queue<T> l)
		{
			l.Clear();
		}, delegate(Queue<T> l)
		{
			l.Clear();
		});
	}
}
