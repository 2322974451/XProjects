using System;

namespace XMainClient
{
	// Token: 0x02000B75 RID: 2933
	internal class Process_PtcG2C_TajieHelpNotify
	{
		// Token: 0x0600A93B RID: 43323 RVA: 0x001E1CB3 File Offset: 0x001DFEB3
		public static void Process(PtcG2C_TajieHelpNotify roPtc)
		{
			TaJieHelpDocument.Doc.OnGetPtcMes(roPtc);
		}
	}
}
