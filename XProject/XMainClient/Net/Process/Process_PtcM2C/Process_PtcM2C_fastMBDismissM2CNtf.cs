using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_fastMBDismissM2CNtf
	{

		public static void Process(PtcM2C_fastMBDismissM2CNtf roPtc)
		{
			DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_QUICKBATTLE_DISMISS", new object[]
			{
				roPtc.Data.quitRoleName
			}), "fece00");
		}
	}
}
