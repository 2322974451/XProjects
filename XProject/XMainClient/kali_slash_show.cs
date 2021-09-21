using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A18 RID: 2584
	internal class kali_slash_show
	{
		// Token: 0x06009E1A RID: 40474 RVA: 0x0019DF30 File Offset: 0x0019C130
		public static bool Do(List<XActor> actors)
		{
			bool flag = actors != null && actors.Count == XGame.RoleCount;
			if (flag)
			{
				bool flag2 = actors[0].Dummy.BillBoard != null;
				if (flag2)
				{
					actors[0].Dummy.BillBoard.HideBillboard();
				}
				for (int i = 1; i < XGame.RoleCount; i++)
				{
					XSelectcharStage.ShowBillboard(actors[i].Dummy);
				}
				bool flag3 = !kali_slash_show._start;
				if (flag3)
				{
					kali_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(kali_slash_show.ResetBound), actors);
					kali_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				kali_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(kali_slash_show.token);
			}
			return true;
		}

		// Token: 0x06009E1B RID: 40475 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003801 RID: 14337
		private static bool _start = false;

		// Token: 0x04003802 RID: 14338
		private static uint token = 0U;
	}
}
