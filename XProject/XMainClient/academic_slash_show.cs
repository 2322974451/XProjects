using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B77 RID: 2935
	internal class academic_slash_show
	{
		// Token: 0x0600A93F RID: 43327 RVA: 0x001E1CD8 File Offset: 0x001DFED8
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
				bool flag3 = !academic_slash_show._start;
				if (flag3)
				{
					academic_slash_show.token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(academic_slash_show.ResetBound), actors);
					academic_slash_show._start = true;
				}
			}
			bool flag4 = actors == null;
			if (flag4)
			{
				academic_slash_show._start = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(academic_slash_show.token);
			}
			return true;
		}

		// Token: 0x0600A940 RID: 43328 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003E94 RID: 16020
		private static bool _start = false;

		// Token: 0x04003E95 RID: 16021
		private static uint token = 0U;
	}
}
