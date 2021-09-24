using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_RefreshWeeklyTask
	{

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

		public static void OnTimeout(RefreshWeeklyTaskArg oArg)
		{
		}
	}
}
