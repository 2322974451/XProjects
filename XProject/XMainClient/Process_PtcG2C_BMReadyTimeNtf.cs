using System;

namespace XMainClient
{
	// Token: 0x0200155B RID: 5467
	internal class Process_PtcG2C_BMReadyTimeNtf
	{
		// Token: 0x0600EA86 RID: 60038 RVA: 0x003446A0 File Offset: 0x003428A0
		public static void Process(PtcG2C_BMReadyTimeNtf roPtc)
		{
			XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			specificDocument.SetTime(roPtc.Data.time);
		}
	}
}
