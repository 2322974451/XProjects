using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200118B RID: 4491
	internal class Process_PtcG2C_NotifyRoleEmpty2Watcher
	{
		// Token: 0x0600DAF8 RID: 56056 RVA: 0x0032E4D0 File Offset: 0x0032C6D0
		public static void Process(PtcG2C_NotifyRoleEmpty2Watcher roPtc)
		{
			bool flag = XSingleton<XScene>.singleton.bSpectator && !DlgBase<SpectateLevelRewardView, SpectateLevelRewardBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.IsVisible();
				if (!flag2)
				{
					bool flag3 = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
					if (!flag3)
					{
						bool flag4 = DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.BigRewardHandler != null && DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>.singleton.BigRewardHandler.IsVisible();
						if (!flag4)
						{
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowBackToMainCityTips();
						}
					}
				}
			}
		}
	}
}
