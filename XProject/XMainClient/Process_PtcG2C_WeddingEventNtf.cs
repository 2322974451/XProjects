using System;

namespace XMainClient
{
	// Token: 0x020015B0 RID: 5552
	internal class Process_PtcG2C_WeddingEventNtf
	{
		// Token: 0x0600EBE7 RID: 60391 RVA: 0x003465E0 File Offset: 0x003447E0
		public static void Process(PtcG2C_WeddingEventNtf roPtc)
		{
			XWeddingDocument.Doc.WeddingSceneEventNtf(roPtc);
		}
	}
}
