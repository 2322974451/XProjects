using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetWeeklyTaskInfo
	{

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

		public static void OnTimeout(GetWeeklyTaskInfoArg oArg)
		{
		}
	}
}
