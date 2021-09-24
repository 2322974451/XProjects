using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetWeeklyTaskReward
	{

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

		public static void OnTimeout(GetWeeklyTaskRewardArg oArg)
		{
		}
	}
}
