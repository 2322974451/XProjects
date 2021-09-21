using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001392 RID: 5010
	internal class Process_RpcC2G_DailyTaskAskHelp
	{
		// Token: 0x0600E341 RID: 58177 RVA: 0x0033A194 File Offset: 0x00338394
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

		// Token: 0x0600E342 RID: 58178 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DailyTaskAskHelpArg oArg)
		{
		}
	}
}
