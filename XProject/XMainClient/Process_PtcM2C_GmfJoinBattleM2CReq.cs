using System;

namespace XMainClient
{
	// Token: 0x020012BC RID: 4796
	internal class Process_PtcM2C_GmfJoinBattleM2CReq
	{
		// Token: 0x0600DFD1 RID: 57297 RVA: 0x00335298 File Offset: 0x00333498
		public static void Process(PtcM2C_GmfJoinBattleM2CReq roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnGmfJoinBattle(roPtc.Data);
		}
	}
}
