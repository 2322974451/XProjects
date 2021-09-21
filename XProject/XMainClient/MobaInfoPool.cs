using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000959 RID: 2393
	public class MobaInfoPool
	{
		// Token: 0x06009010 RID: 36880 RVA: 0x001466CC File Offset: 0x001448CC
		public static void Clear()
		{
			bool flag = MobaInfoPool._pool != null;
			if (flag)
			{
				MobaInfoPool._pool.Clear();
				MobaInfoPool._pool = null;
			}
		}

		// Token: 0x06009011 RID: 36881 RVA: 0x001466FC File Offset: 0x001448FC
		public static MobaReminder GetInfo()
		{
			bool flag = MobaInfoPool._pool == null;
			if (flag)
			{
				MobaInfoPool._pool = new Queue<MobaReminder>();
			}
			return (MobaInfoPool._pool.Count > 0) ? MobaInfoPool._pool.Dequeue() : new MobaReminder();
		}

		// Token: 0x06009012 RID: 36882 RVA: 0x00146744 File Offset: 0x00144944
		public static void Recycle(MobaReminder info)
		{
			bool flag = MobaInfoPool._pool == null;
			if (!flag)
			{
				MobaInfoPool._pool.Enqueue(info);
			}
		}

		// Token: 0x04002FAC RID: 12204
		private static Queue<MobaReminder> _pool;
	}
}
