using System;

namespace XMainClient
{
	// Token: 0x020015AC RID: 5548
	internal class Process_PtcG2C_WeddingStateNtf
	{
		// Token: 0x0600EBD7 RID: 60375 RVA: 0x003464B0 File Offset: 0x003446B0
		public static void Process(PtcG2C_WeddingStateNtf roPtc)
		{
			XWeddingDocument.Doc.WeddingStateNtf(roPtc);
		}
	}
}
