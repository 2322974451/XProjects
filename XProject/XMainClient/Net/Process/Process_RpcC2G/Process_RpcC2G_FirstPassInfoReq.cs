using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_FirstPassInfoReq
	{

		public static void OnReply(FirstPassInfoReqArg oArg, FirstPassInfoReqRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassInfo(oRes);
		}

		public static void OnTimeout(FirstPassInfoReqArg oArg)
		{
		}
	}
}
