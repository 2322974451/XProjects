using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_DailyTaskGiveUp
	{

		public static void OnReply(DailyTaskGiveUpArg oArg, DailyTaskGiveUpRes oRes)
		{
			XGuildDailyTaskDocument.Doc.OnGiveUpTask(oRes);
		}

		public static void OnTimeout(DailyTaskGiveUpArg oArg)
		{
		}
	}
}
