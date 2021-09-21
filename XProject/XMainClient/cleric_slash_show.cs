using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B7D RID: 2941
	internal class cleric_slash_show
	{
		// Token: 0x0600A951 RID: 43345 RVA: 0x001E1FE4 File Offset: 0x001E01E4
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
				bool flag3 = !cleric_slash_show._start;
				if (flag3)
				{
					cleric_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(cleric_slash_show.ResetBound), actors);
					cleric_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				cleric_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(cleric_slash_show.token);
			}
			return true;
		}

		// Token: 0x0600A952 RID: 43346 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003E9A RID: 16026
		private static bool _start = false;

		// Token: 0x04003E9B RID: 16027
		private static uint token = 0U;
	}
}
