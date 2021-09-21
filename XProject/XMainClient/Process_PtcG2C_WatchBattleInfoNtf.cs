using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001169 RID: 4457
	internal class Process_PtcG2C_WatchBattleInfoNtf
	{
		// Token: 0x0600DA79 RID: 55929 RVA: 0x0032DAF0 File Offset: 0x0032BCF0
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
