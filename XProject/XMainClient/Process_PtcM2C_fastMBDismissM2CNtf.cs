using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011FA RID: 4602
	internal class Process_PtcM2C_fastMBDismissM2CNtf
	{
		// Token: 0x0600DCAD RID: 56493 RVA: 0x00330AE0 File Offset: 0x0032ECE0
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
