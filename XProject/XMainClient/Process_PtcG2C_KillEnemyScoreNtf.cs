using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200137E RID: 4990
	internal class Process_PtcG2C_KillEnemyScoreNtf
	{
		// Token: 0x0600E2EF RID: 58095 RVA: 0x00339B90 File Offset: 0x00337D90
		public static void Process(PtcG2C_KillEnemyScoreNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.UpdateKill(roPtc.Data.score);
			}
		}
	}
}
