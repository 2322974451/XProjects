using System;

namespace XMainClient
{
	// Token: 0x020013F1 RID: 5105
	internal class Process_PtcM2C_MakePartnerResultNtf
	{
		// Token: 0x0600E4C8 RID: 58568 RVA: 0x0033C1F4 File Offset: 0x0033A3F4
		public static void Process(PtcM2C_MakePartnerResultNtf roPtc)
		{
			XPartnerDocument.Doc.MakePartnerResult(roPtc);
		}
	}
}
