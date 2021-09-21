using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200138D RID: 5005
	internal class Process_RpcC2G_GetDailyTaskInfo
	{
		// Token: 0x0600E32A RID: 58154 RVA: 0x0033A015 File Offset: 0x00338215
		public static void OnReply(GetDailyTaskInfoArg oArg, GetDailyTaskInfoRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTasks(oRes);
			XActivityDocument.Doc.OnGetDayCount();
		}

		// Token: 0x0600E32B RID: 58155 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDailyTaskInfoArg oArg)
		{
		}
	}
}
