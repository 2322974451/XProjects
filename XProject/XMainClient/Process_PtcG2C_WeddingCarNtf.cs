using System;

namespace XMainClient
{
	// Token: 0x020015D4 RID: 5588
	internal class Process_PtcG2C_WeddingCarNtf
	{
		// Token: 0x0600EC7A RID: 60538 RVA: 0x0034726C File Offset: 0x0034546C
		public static void Process(PtcG2C_WeddingCarNtf roPtc)
		{
			XWeddingDocument.Doc.OnGetWeddingCarNtf(roPtc);
		}
	}
}
