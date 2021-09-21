using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200113F RID: 4415
	internal class Process_PtcG2C_fastMBDismissNtf
	{
		// Token: 0x0600D9C4 RID: 55748 RVA: 0x0032B8C0 File Offset: 0x00329AC0
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
