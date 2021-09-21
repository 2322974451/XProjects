using System;

namespace XMainClient
{
	// Token: 0x020011C5 RID: 4549
	internal class Process_PtcG2C_WorldBossAttrNtf
	{
		// Token: 0x0600DBDB RID: 56283 RVA: 0x0032F938 File Offset: 0x0032DB38
		public static void Process(PtcG2C_WorldBossAttrNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.OnGetAttrCount(roPtc.Data);
		}
	}
}
