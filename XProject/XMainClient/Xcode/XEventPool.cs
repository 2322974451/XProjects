using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEventPool<T> where T : XEventArgs, new()
	{

		public static void Clear()
		{
			bool flag = XEventPool<T>._pool != null;
			if (flag)
			{
				XEventPool<T>._pool.Clear();
				XEventPool<T>._pool = null;
			}
		}

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

		public static void Recycle(T args)
		{
			XEventPool<T>._pool.Enqueue(args);
		}

		private static Queue<T> _pool = null;
	}
}
