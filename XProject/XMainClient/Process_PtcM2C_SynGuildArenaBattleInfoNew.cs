using System;

namespace XMainClient
{
	// Token: 0x02001272 RID: 4722
	internal class Process_PtcM2C_SynGuildArenaBattleInfoNew
	{
		// Token: 0x0600DEA3 RID: 56995 RVA: 0x003337F4 File Offset: 0x003319F4
		public static void Process(PtcM2C_SynGuildArenaBattleInfoNew roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnSynGuildArenaBattleInfos(roPtc.Data);
		}
	}
}
