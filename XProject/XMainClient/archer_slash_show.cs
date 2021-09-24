using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class archer_slash_show
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

		private static void ResetBound(object o)
		{
		}

		private static bool _start = false;

		private static uint token = 0U;
	}
}
