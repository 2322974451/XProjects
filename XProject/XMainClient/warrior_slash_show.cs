using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B88 RID: 2952
	internal class warrior_slash_show
	{
		// Token: 0x0600A981 RID: 43393 RVA: 0x001E3154 File Offset: 0x001E1354
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
				bool flag3 = !warrior_slash_show._start;
				if (flag3)
				{
					warrior_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(warrior_slash_show.ResetBound), actors);
					warrior_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				warrior_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(warrior_slash_show.token);
			}
			return true;
		}

		// Token: 0x0600A982 RID: 43394 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003EAD RID: 16045
		private static bool _start = false;

		// Token: 0x04003EAE RID: 16046
		private static uint token = 0U;
	}
}
