using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020010BF RID: 4287
	internal class Process_PtcG2C_GuildGoblinKillNtf
	{
		// Token: 0x0600D7B8 RID: 55224 RVA: 0x003288B0 File Offset: 0x00326AB0
		public static void Process(PtcG2C_GuildGoblinKillNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
			}
		}
	}
}
