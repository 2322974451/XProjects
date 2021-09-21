using System;

namespace XMainClient
{
	// Token: 0x02001662 RID: 5730
	internal class Process_PtcM2C_TaskRefreshNtf
	{
		// Token: 0x0600EED5 RID: 61141 RVA: 0x0034A574 File Offset: 0x00348774
		public static void Process(PtcM2C_TaskRefreshNtf roPtc)
		{
			XGuildDailyTaskDocument.Doc.OnTaskRefreshNtf(roPtc);
		}
	}
}
