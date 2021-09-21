using System;

namespace XMainClient
{
	// Token: 0x02001185 RID: 4485
	internal class Process_PtcG2C_MulActivityStateChange
	{
		// Token: 0x0600DAE3 RID: 56035 RVA: 0x0032E398 File Offset: 0x0032C598
		public static void Process(PtcG2C_MulActivityStateChange roPtc)
		{
			XActivityDocument.Doc.ChangeActivityState(roPtc.Data.changeInfo);
		}
	}
}
