using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015F8 RID: 5624
	internal class Process_RpcC2G_GetWeeklyTaskReward
	{
		// Token: 0x0600ED0E RID: 60686 RVA: 0x00347DC8 File Offset: 0x00345FC8
		public static void OnReply(GetWeeklyTaskRewardArg oArg, GetWeeklyTaskRewardRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.OnGetWeeklyTaskReward(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x0600ED0F RID: 60687 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetWeeklyTaskRewardArg oArg)
		{
		}
	}
}
