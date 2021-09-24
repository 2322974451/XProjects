using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_SmeltItem
	{

		public static void OnReply(SmeltItemArg oArg, SmeltItemRes oRes)
		{
			XSmeltDocument.Doc.OnSmeltBack(oRes);
		}

		public static void OnTimeout(SmeltItemArg oArg)
		{
		}
	}
}
