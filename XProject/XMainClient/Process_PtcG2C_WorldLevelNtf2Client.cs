using System;

namespace XMainClient
{
	// Token: 0x02001673 RID: 5747
	internal class Process_PtcG2C_WorldLevelNtf2Client
	{
		// Token: 0x0600EF1C RID: 61212 RVA: 0x0034AC68 File Offset: 0x00348E68
		public static void Process(PtcG2C_WorldLevelNtf2Client roPtc)
		{
			XBackFlowDocument.Doc.OnGetWorldLevelNotify(roPtc);
		}
	}
}
