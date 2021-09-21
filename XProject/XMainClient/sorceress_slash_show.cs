using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B86 RID: 2950
	internal class sorceress_slash_show
	{
		// Token: 0x0600A979 RID: 43385 RVA: 0x001E2F68 File Offset: 0x001E1168
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
				bool flag3 = !sorceress_slash_show._start2;
				if (flag3)
				{
					sorceress_slash_show.token3 = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(sorceress_slash_show.ResetBound), actors);
					sorceress_slash_show._start2 = true;
				}
			}
			bool flag4 = !sorceress_slash_show._start;
			if (flag4)
			{
				sorceress_slash_show.token1 = XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, new XTimerMgr.ElapsedEventHandler(sorceress_slash_show.Disappear), null);
				sorceress_slash_show.token2 = XSingleton<XTimerMgr>.singleton.SetTimer(0.9f, new XTimerMgr.ElapsedEventHandler(sorceress_slash_show.Appear), null);
				sorceress_slash_show._start = true;
			}
			bool flag5 = actors != null && actors.Count > 0;
			if (flag5)
			{
				sorceress_slash_show._sorceress = actors[0];
			}
			bool flag6 = actors == null;
			if (flag6)
			{
				sorceress_slash_show._start = false;
				sorceress_slash_show._start2 = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(sorceress_slash_show.token1);
				XSingleton<XTimerMgr>.singleton.KillTimer(sorceress_slash_show.token2);
				XSingleton<XTimerMgr>.singleton.KillTimer(sorceress_slash_show.token3);
			}
			return true;
		}

		// Token: 0x0600A97A RID: 43386 RVA: 0x001E30E8 File Offset: 0x001E12E8
		private static void Disappear(object o)
		{
			sorceress_slash_show._sorceress.EngineObject.SetActive(false, "");
		}

		// Token: 0x0600A97B RID: 43387 RVA: 0x001E3101 File Offset: 0x001E1301
		private static void Appear(object o)
		{
			sorceress_slash_show._sorceress.EngineObject.SetActive(true, "");
		}

		// Token: 0x0600A97C RID: 43388 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private static void ResetBound(object o)
		{
		}

		// Token: 0x04003EA7 RID: 16039
		private static bool _start = false;

		// Token: 0x04003EA8 RID: 16040
		private static bool _start2 = false;

		// Token: 0x04003EA9 RID: 16041
		private static uint token1 = 0U;

		// Token: 0x04003EAA RID: 16042
		private static uint token2 = 0U;

		// Token: 0x04003EAB RID: 16043
		private static uint token3 = 0U;

		// Token: 0x04003EAC RID: 16044
		private static XActor _sorceress = null;
	}
}
