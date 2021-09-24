using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_WatchBattleInfoNtf
	{

		public static void Process(PtcG2C_WatchBattleInfoNtf roPtc)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateHandler.OnMessageChange(roPtc.Data.watchNum, roPtc.Data.commendNum);
			}
			bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnSpectateMessageChange(roPtc.Data.watchNum, roPtc.Data.commendNum);
			}
		}
	}
}
