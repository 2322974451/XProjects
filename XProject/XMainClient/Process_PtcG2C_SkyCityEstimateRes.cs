using System;

namespace XMainClient
{
	// Token: 0x020012CF RID: 4815
	internal class Process_PtcG2C_SkyCityEstimateRes
	{
		// Token: 0x0600E01F RID: 57375 RVA: 0x00335918 File Offset: 0x00333B18
		public static void Process(PtcG2C_SkyCityEstimateRes roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleEndInfo(roPtc);
		}
	}
}
