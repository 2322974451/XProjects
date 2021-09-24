using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaAddExpNtf
	{

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
