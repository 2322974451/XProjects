using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015F6 RID: 5622
	internal class Process_RpcC2G_GetWeeklyTaskInfo
	{
		// Token: 0x0600ED05 RID: 60677 RVA: 0x00347D08 File Offset: 0x00345F08
		public static void OnReply(GetWeeklyTaskInfoArg oArg, GetWeeklyTaskInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.OnGetWeeklyTaskInfo(oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x0600ED06 RID: 60678 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetWeeklyTaskInfoArg oArg)
		{
		}
	}
}
