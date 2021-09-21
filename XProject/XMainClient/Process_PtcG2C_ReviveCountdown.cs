using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001062 RID: 4194
	internal class Process_PtcG2C_ReviveCountdown
	{
		// Token: 0x0600D642 RID: 54850 RVA: 0x00325DA4 File Offset: 0x00323FA4
		public static void Process(PtcG2C_ReviveCountdown roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowAutoReviveFrame(roPtc.Data.countdownTime, roPtc.Data.revivecost, roPtc.Data.revivecosttype);
			}
		}
	}
}
