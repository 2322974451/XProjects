using System;
using System.Collections.Generic;
using System.Threading;

namespace XMainClient
{
	// Token: 0x02000EBD RID: 3773
	internal class XNetEventPool
	{
		// Token: 0x0600C874 RID: 51316 RVA: 0x002CE738 File Offset: 0x002CC938
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

		// Token: 0x0600C875 RID: 51317 RVA: 0x002CE799 File Offset: 0x002CC999
		public static void Recycle(NetEvent e)
		{
			Monitor.Enter(XNetEventPool._pool);
			XNetEventPool._pool.Enqueue(e);
			Monitor.Exit(XNetEventPool._pool);
		}

		// Token: 0x0600C876 RID: 51318 RVA: 0x002CE7BE File Offset: 0x002CC9BE
		public static void RecycleNoLock(NetEvent e)
		{
			XNetEventPool._pool.Enqueue(e);
		}

		// Token: 0x0600C877 RID: 51319 RVA: 0x002CE7CD File Offset: 0x002CC9CD
		public static void Clear()
		{
			Monitor.Enter(XNetEventPool._pool);
			XNetEventPool._pool.Clear();
			Monitor.Exit(XNetEventPool._pool);
		}

		// Token: 0x040058A8 RID: 22696
		private static Queue<NetEvent> _pool = new Queue<NetEvent>(128);
	}
}
