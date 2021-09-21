using System;

namespace XMainClient
{
	// Token: 0x0200161C RID: 5660
	internal class Process_PtcM2C_DailyTaskEventNtf
	{
		// Token: 0x0600EDA9 RID: 60841 RVA: 0x00348B10 File Offset: 0x00346D10
		public static void Process(PtcM2C_DailyTaskEventNtf roPtc)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTaskEvent(roPtc);
		}
	}
}
