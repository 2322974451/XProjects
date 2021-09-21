using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B7B RID: 2939
	internal class assassin_slash_show
	{
		// Token: 0x0600A94B RID: 43339 RVA: 0x001E1EE0 File Offset: 0x001E00E0
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
				bool flag3 = !assassin_slash_show._start;
				if (flag3)
				{
					assassin_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(assassin_slash_show.ResetBound), actors);
					assassin_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				assassin_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(assassin_slash_show.token);
			}
			return true;
		}

		// Token: 0x0600A94C RID: 43340 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003E98 RID: 16024
		private static bool _start = false;

		// Token: 0x04003E99 RID: 16025
		private static uint token = 0U;
	}
}
