using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015FA RID: 5626
	internal class Process_RpcC2G_RefreshWeeklyTask
	{
		// Token: 0x0600ED17 RID: 60695 RVA: 0x00347E88 File Offset: 0x00346088
		public static void OnReply(RefreshWeeklyTaskArg oArg, RefreshWeeklyTaskRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.OnRefreshTaskList(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x0600ED18 RID: 60696 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RefreshWeeklyTaskArg oArg)
		{
		}
	}
}
