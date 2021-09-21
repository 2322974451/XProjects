using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FB6 RID: 4022
	internal class XEventPool<T> where T : XEventArgs, new()
	{
		// Token: 0x0600D122 RID: 53538 RVA: 0x00305AE8 File Offset: 0x00303CE8
		public static void Clear()
		{
			bool flag = XEventPool<T>._pool != null;
			if (flag)
			{
				XEventPool<T>._pool.Clear();
				XEventPool<T>._pool = null;
			}
		}

		// Token: 0x0600D123 RID: 53539 RVA: 0x00305B18 File Offset: 0x00303D18
		public static T GetEvent()
		{
			bool flag = XEventPool<T>._pool == null;
			if (flag)
			{
				XEventPool<T>._pool = new Queue<T>();
				XSingleton<XEventMgr>.singleton.RegisterEventPool(new EventPoolClear(XEventPool<T>.Clear));
			}
			bool flag2 = XEventPool<T>._pool.Count > 0;
			T result;
			if (flag2)
			{
				T t = XEventPool<T>._pool.Dequeue();
				bool flag3 = t == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("XEvent Type should be ", typeof(T).ToString(), " but is ", t.ToString(), null, null);
				}
				t.Token = XSingleton<XCommon>.singleton.UniqueToken;
				result = t;
			}
			else
			{
				result = Activator.CreateInstance<T>();
			}
			return result;
		}

		// Token: 0x0600D124 RID: 53540 RVA: 0x00305BD9 File Offset: 0x00303DD9
		public static void Recycle(T args)
		{
			XEventPool<T>._pool.Enqueue(args);
		}

		// Token: 0x04005EA6 RID: 24230
		private static Queue<T> _pool = null;
	}
}
