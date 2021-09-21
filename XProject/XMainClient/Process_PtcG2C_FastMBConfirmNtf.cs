using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200113C RID: 4412
	internal class Process_PtcG2C_FastMBConfirmNtf
	{
		// Token: 0x0600D9B8 RID: 55736 RVA: 0x0032B80C File Offset: 0x00329A0C
		public static void Process(PtcG2C_FastMBConfirmNtf roPtc)
		{
			DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}
	}
}
