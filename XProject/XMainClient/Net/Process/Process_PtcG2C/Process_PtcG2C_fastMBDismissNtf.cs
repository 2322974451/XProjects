using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_fastMBDismissNtf
	{

		public static void Process(PtcG2C_fastMBDismissNtf roPtc)
		{
			DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_QUICKBATTLE_DISMISS", new object[]
			{
				roPtc.Data.quitRoleName
			}), "fece00");
		}
	}
}
