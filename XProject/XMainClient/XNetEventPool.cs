using System;
using System.Collections.Generic;
using System.Threading;

namespace XMainClient
{

	internal class XNetEventPool
	{

		public static NetEvent GetEvent()
		{
			NetEvent netEvent = null;
			Monitor.Enter(XNetEventPool._pool);
			bool flag = XNetEventPool._pool.Count > 0;
			if (flag)
			{
				netEvent = XNetEventPool._pool.Dequeue();
			}
			Monitor.Exit(XNetEventPool._pool);
			bool flag2 = netEvent != null;
			NetEvent result;
			if (flag2)
			{
				netEvent.Reset();
				result = netEvent;
			}
			else
			{
				result = new NetEvent();
			}
			return result;
		}

		public static void Recycle(NetEvent e)
		{
			Monitor.Enter(XNetEventPool._pool);
			XNetEventPool._pool.Enqueue(e);
			Monitor.Exit(XNetEventPool._pool);
		}

		public static void RecycleNoLock(NetEvent e)
		{
			XNetEventPool._pool.Enqueue(e);
		}

		public static void Clear()
		{
			Monitor.Enter(XNetEventPool._pool);
			XNetEventPool._pool.Clear();
			Monitor.Exit(XNetEventPool._pool);
		}

		private static Queue<NetEvent> _pool = new Queue<NetEvent>(128);
	}
}
