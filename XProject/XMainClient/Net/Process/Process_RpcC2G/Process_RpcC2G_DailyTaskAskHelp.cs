using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_DailyTaskAskHelp
	{

		public static void OnReply(DailyTaskAskHelpArg oArg, DailyTaskAskHelpRes oRes)
		{
			bool flag = oArg.task_type == PeriodTaskType.PeriodTaskType_Daily;
			if (flag)
			{
				XGuildDailyTaskDocument.Doc.OnGetDailyHelpReply(oArg, oRes);
			}
			else
			{
				XGuildWeeklyBountyDocument.Doc.OnGetWeeklyHelpReply(oArg, oRes);
			}
		}

		public static void OnTimeout(DailyTaskAskHelpArg oArg)
		{
		}
	}
}
