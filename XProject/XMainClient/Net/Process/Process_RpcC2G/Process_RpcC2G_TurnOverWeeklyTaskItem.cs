using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_TurnOverWeeklyTaskItem
	{

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

		public static void OnTimeout(TurnOverWeeklyTaskItemArg oArg)
		{
		}
	}
}
