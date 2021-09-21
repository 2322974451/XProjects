using System;

namespace XMainClient
{
	// Token: 0x02001181 RID: 4481
	internal class Process_PtcG2C_SynGuildArenaBattleInfo
	{
		// Token: 0x0600DAD5 RID: 56021 RVA: 0x0032E2C4 File Offset: 0x0032C4C4
		public static void Process(PtcG2C_SynGuildArenaBattleInfo roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnSynGuildArenaBattleInfos(roPtc.Data);
		}
	}
}
