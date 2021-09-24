using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class MobaInfoPool
	{

		public static void Clear()
		{
			bool flag = MobaInfoPool._pool != null;
			if (flag)
			{
				MobaInfoPool._pool.Clear();
				MobaInfoPool._pool = null;
			}
		}

		public static MobaReminder GetInfo()
		{
			bool flag = MobaInfoPool._pool == null;
			if (flag)
			{
				MobaInfoPool._pool = new Queue<MobaReminder>();
			}
			return (MobaInfoPool._pool.Count > 0) ? MobaInfoPool._pool.Dequeue() : new MobaReminder();
		}

		public static void Recycle(MobaReminder info)
		{
			bool flag = MobaInfoPool._pool == null;
			if (!flag)
			{
				MobaInfoPool._pool.Enqueue(info);
			}
		}

		private static Queue<MobaReminder> _pool;
	}
}
