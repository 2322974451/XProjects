using System;

namespace XMainClient
{
	// Token: 0x020010E3 RID: 4323
	internal class Process_PtcG2C_ExpFindBackNtf
	{
		// Token: 0x0600D844 RID: 55364 RVA: 0x00329500 File Offset: 0x00327700
		public static void Process(PtcG2C_ExpFindBackNtf roPtc)
		{
			XFindExpDocument.Doc.OnGetExpInfo(roPtc);
		}
	}
}
