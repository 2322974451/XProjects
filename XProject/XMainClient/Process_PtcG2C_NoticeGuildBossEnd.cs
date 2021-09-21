using System;

namespace XMainClient
{
	// Token: 0x0200116D RID: 4461
	internal class Process_PtcG2C_NoticeGuildBossEnd
	{
		// Token: 0x0600DA89 RID: 55945 RVA: 0x0032DCA4 File Offset: 0x0032BEA4
		public static void Process(PtcG2C_NoticeGuildBossEnd roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.DragonChallengeResult(roPtc.Data);
		}
	}
}
