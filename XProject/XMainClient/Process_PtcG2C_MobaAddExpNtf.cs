using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001556 RID: 5462
	internal class Process_PtcG2C_MobaAddExpNtf
	{
		// Token: 0x0600EA71 RID: 60017 RVA: 0x00344358 File Offset: 0x00342558
		public static void Process(PtcG2C_MobaAddExpNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.SetGetExpAnimation((uint)roPtc.Data.addexp, roPtc.Data.posxz);
			}
		}
	}
}
