using System;

namespace XMainClient
{
	// Token: 0x02001189 RID: 4489
	internal class Process_PtcG2C_WorldBossStateNtf
	{
		// Token: 0x0600DAF1 RID: 56049 RVA: 0x0032E484 File Offset: 0x0032C684
		public static void Process(PtcG2C_WorldBossStateNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.OnWorldBossStateNtf(roPtc.Data);
		}
	}
}
