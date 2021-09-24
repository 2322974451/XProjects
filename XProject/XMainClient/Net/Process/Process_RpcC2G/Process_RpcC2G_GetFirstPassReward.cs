using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetFirstPassReward
	{

		public static void OnReply(GetFirstPassRewardArg oArg, GetFirstPassRewardRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassReward(oRes);
		}

		public static void OnTimeout(GetFirstPassRewardArg oArg)
		{
		}
	}
}
