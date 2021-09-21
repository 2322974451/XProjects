using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020011F8 RID: 4600
	internal class Process_PtcM2C_FastMBConfirmM2CNtf
	{
		// Token: 0x0600DCA6 RID: 56486 RVA: 0x0032B80C File Offset: 0x00329A0C
		public static void Process(PtcM2C_FastMBConfirmM2CNtf roPtc)
		{
			DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}
	}
}
