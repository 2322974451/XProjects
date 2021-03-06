using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_ReviveCountdown
	{

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
