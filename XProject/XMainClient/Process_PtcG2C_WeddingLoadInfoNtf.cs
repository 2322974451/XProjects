using System;

namespace XMainClient
{
	// Token: 0x020015AA RID: 5546
	internal class Process_PtcG2C_WeddingLoadInfoNtf
	{
		// Token: 0x0600EBD0 RID: 60368 RVA: 0x0034644C File Offset: 0x0034464C
		public static void Process(PtcG2C_WeddingLoadInfoNtf roPtc)
		{
			XWeddingDocument.Doc.OnWeddingLoadingInfoNtf(roPtc);
		}
	}
}
