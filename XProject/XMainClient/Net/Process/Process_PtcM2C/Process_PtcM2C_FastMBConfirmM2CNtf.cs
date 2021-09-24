using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcM2C_FastMBConfirmM2CNtf
	{

		public static void Process(PtcM2C_FastMBConfirmM2CNtf roPtc)
		{
			DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}
	}
}
