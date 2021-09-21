using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001608 RID: 5640
	internal class Process_RpcC2G_TurnOverWeeklyTaskItem
	{
		// Token: 0x0600ED52 RID: 60754 RVA: 0x00348294 File Offset: 0x00346494
		public static void OnReply(TurnOverWeeklyTaskItemArg oArg, TurnOverWeeklyTaskItemRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.OnTurnOverWeeklyTaskReply(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x0600ED53 RID: 60755 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TurnOverWeeklyTaskItemArg oArg)
		{
		}
	}
}
