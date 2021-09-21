using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200138F RID: 5007
	internal class Process_RpcC2G_GetDailyTaskReward
	{
		// Token: 0x0600E333 RID: 58163 RVA: 0x0033A0B1 File Offset: 0x003382B1
		public static void OnReply(GetDailyTaskRewardArg oArg, GetDailyTaskRewardRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTaskReward(oArg, oRes);
		}

		// Token: 0x0600E334 RID: 58164 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDailyTaskRewardArg oArg)
		{
		}
	}
}
