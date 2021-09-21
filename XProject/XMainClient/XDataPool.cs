using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008BC RID: 2236
	public class XDataPool<T> where T : XDataBase, new()
	{
		// Token: 0x06008728 RID: 34600 RVA: 0x00114464 File Offset: 0x00112664
		public static T GetData()
		{
			bool flag = XDataPool<T>._pool.Count > 0;
			T result;
			if (flag)
			{
				T t = XDataPool<T>._pool.Dequeue();
				t.Init();
				t.bRecycled = false;
				result = t;
			}
			else
			{
				T t2 = Activator.CreateInstance<T>();
				t2.Init();
				t2.bRecycled = false;
				result = t2;
			}
			return result;
		}

		// Token: 0x06008729 RID: 34601 RVA: 0x001144D0 File Offset: 0x001126D0
		public static void Recycle(T data)
		{
			bool flag = !data.bRecycled;
			if (flag)
			{
				XDataPool<T>._pool.Enqueue(data);
				data.bRecycled = true;
			}
		}

		// Token: 0x04002A9C RID: 10908
		private static Queue<T> _pool = new Queue<T>();
	}
}
