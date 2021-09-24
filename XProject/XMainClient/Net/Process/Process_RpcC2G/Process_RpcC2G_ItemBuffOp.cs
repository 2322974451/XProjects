using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ItemBuffOp
	{

		public static void OnReply(ItemBuffOpArg oArg, ItemBuffOpRes oRes)
		{
			XGuildResContentionBuffDocument.Doc.OnGetPersonalBuffOperationResult(oArg, oRes);
		}

		public static void OnTimeout(ItemBuffOpArg oArg)
		{
		}
	}
}
