using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_FirstPassGetTopRoleInfo
	{

		public static void OnReply(FirstPassGetTopRoleInfoArg oArg, FirstPassGetTopRoleInfoRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassTopRoleInfo(oRes);
		}

		public static void OnTimeout(FirstPassGetTopRoleInfoArg oArg)
		{
		}
	}
}
