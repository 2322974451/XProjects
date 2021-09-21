using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013AD RID: 5037
	internal class Process_RpcC2G_DailyTaskGiveUp
	{
		// Token: 0x0600E3B1 RID: 58289 RVA: 0x0033AAA1 File Offset: 0x00338CA1
		public static void OnReply(DailyTaskGiveUpArg oArg, DailyTaskGiveUpRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGiveUpTask(oRes);
		}

		// Token: 0x0600E3B2 RID: 58290 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DailyTaskGiveUpArg oArg)
		{
		}
	}
}
