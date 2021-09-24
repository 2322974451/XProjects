using System;

namespace XMainClient
{

	internal class Process_PtcM2C_DailyTaskEventNtf
	{

		public static void Process(PtcM2C_DailyTaskEventNtf roPtc)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTaskEvent(roPtc);
		}
	}
}
