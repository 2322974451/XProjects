using System;

namespace XMainClient
{

	internal class Process_PtcM2C_TaskRefreshNtf
	{

		public static void Process(PtcM2C_TaskRefreshNtf roPtc)
		{
			XGuildDailyTaskDocument.Doc.OnTaskRefreshNtf(roPtc);
		}
	}
}
