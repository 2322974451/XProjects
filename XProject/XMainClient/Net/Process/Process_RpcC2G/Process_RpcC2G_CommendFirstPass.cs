using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_CommendFirstPass
	{

		public static void OnReply(CommendFirstPassArg oArg, CommendFirstPassRes oRes)
		{
			FirstPassDocument.Doc.OnGetCommendFirstPass(oRes);
		}

		public static void OnTimeout(CommendFirstPassArg oArg)
		{
		}
	}
}
