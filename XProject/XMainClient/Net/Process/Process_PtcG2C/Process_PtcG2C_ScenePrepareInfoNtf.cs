using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ScenePrepareInfoNtf
	{

		public static void Process(PtcG2C_ScenePrepareInfoNtf roPtc)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World;
			if (!flag)
			{
				bool isPVPScene = XSingleton<XScene>.singleton.IsPVPScene;
				if (isPVPScene)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLoadingPrompt(roPtc.Data.unreadyroles, true);
				}
				else
				{
					DlgBase<LoadingDlg, LoadingDlgBehaviour>.singleton.SetLoadingPrompt(roPtc.Data.unreadyroles);
				}
				for (int i = 0; i < roPtc.Data.unreadyroles.Count; i++)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("roles: ", roPtc.Data.unreadyroles[i], " not ready yet.", null, null, null);
				}
				bool flag2 = roPtc.Data.unreadyroles.Count > 0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("still has ", roPtc.Data.unreadyroles.Count.ToString(), " unready.", null, null, null);
				}
			}
		}
	}
}
