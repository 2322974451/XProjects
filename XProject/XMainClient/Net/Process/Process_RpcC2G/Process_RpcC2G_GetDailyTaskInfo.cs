using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetDailyTaskInfo
	{

		public static void OnReply(GetDailyTaskInfoArg oArg, GetDailyTaskInfoRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGetDailyTasks(oRes);
			XActivityDocument.Doc.OnGetDayCount();
		}

		public static void OnTimeout(GetDailyTaskInfoArg oArg)
		{
		}
	}
}
