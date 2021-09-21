using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020010D5 RID: 4309
	internal class Process_PtcG2C_TeleportNotice
	{
		// Token: 0x0600D80D RID: 55309 RVA: 0x00328FB8 File Offset: 0x003271B8
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
