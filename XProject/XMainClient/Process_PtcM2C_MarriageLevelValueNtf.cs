using System;

namespace XMainClient
{
	// Token: 0x020016A3 RID: 5795
	internal class Process_PtcM2C_MarriageLevelValueNtf
	{
		// Token: 0x0600EFE2 RID: 61410 RVA: 0x0034C054 File Offset: 0x0034A254
		public static void Process(PtcM2C_MarriageLevelValueNtf roPtc)
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.OnMarriageLevelValueChangeNtf(roPtc.Data);
		}
	}
}
