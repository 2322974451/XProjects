using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildGoblinKillNtf
	{

		public static void Process(PtcG2C_GuildGoblinKillNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
			}
		}
	}
}
