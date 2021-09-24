using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class XDataPool<T> where T : XDataBase, new()
	{

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

		public static void Recycle(T data)
		{
			bool flag = !data.bRecycled;
			if (flag)
			{
				XDataPool<T>._pool.Enqueue(data);
				data.bRecycled = true;
			}
		}

		private static Queue<T> _pool = new Queue<T>();
	}
}
