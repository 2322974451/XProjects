using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_TeleportNotice
	{

		public static void Process(PtcG2C_TeleportNotice roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool onnotice = roPtc.Data.onnotice;
				if (onnotice)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowNotice(XStringDefineProxy.GetString("LEVEL_ALL_TRANSPORT"), 5f, 1f);
				}
				else
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.StopNotice();
				}
			}
		}
	}
}
