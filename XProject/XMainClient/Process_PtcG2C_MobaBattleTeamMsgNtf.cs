using System;

namespace XMainClient
{
	// Token: 0x0200153A RID: 5434
	internal class Process_PtcG2C_MobaBattleTeamMsgNtf
	{
		// Token: 0x0600EA01 RID: 59905 RVA: 0x00343878 File Offset: 0x00341A78
		public static void Process(PtcG2C_MobaBattleTeamMsgNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetBattleMsg(roPtc.Data.teamdata);
		}
	}
}
