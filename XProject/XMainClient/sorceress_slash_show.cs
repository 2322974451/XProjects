using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class sorceress_slash_show
	{

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

		private static void Disappear(object o)
		{
			sorceress_slash_show._sorceress.EngineObject.SetActive(false, "");
		}

		private static void Appear(object o)
		{
			sorceress_slash_show._sorceress.EngineObject.SetActive(true, "");
		}

		private static void ResetBound(object o)
		{
		}

		private static bool _start = false;

		private static bool _start2 = false;

		private static uint token1 = 0U;

		private static uint token2 = 0U;

		private static uint token3 = 0U;

		private static XActor _sorceress = null;
	}
}
