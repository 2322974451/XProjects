using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetDailyTaskReward
	{

		public static void OnReply(GetDailyTaskRewardArg oArg, GetDailyTaskRewardRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTaskReward(oArg, oRes);
		}

		public static void OnTimeout(GetDailyTaskRewardArg oArg)
		{
		}
	}
}
