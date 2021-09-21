using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B79 RID: 2937
	internal class archer_slash_show
	{
		// Token: 0x0600A945 RID: 43333 RVA: 0x001E1DDC File Offset: 0x001DFFDC
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
				bool flag3 = !archer_slash_show._start;
				if (flag3)
				{
					archer_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(archer_slash_show.ResetBound), actors);
					archer_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				archer_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(archer_slash_show.token);
			}
			return true;
		}

		// Token: 0x0600A946 RID: 43334 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003E96 RID: 16022
		private static bool _start = false;

		// Token: 0x04003E97 RID: 16023
		private static uint token = 0U;
	}
}
