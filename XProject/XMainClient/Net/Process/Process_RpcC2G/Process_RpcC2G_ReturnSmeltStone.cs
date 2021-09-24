using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ReturnSmeltStone
	{

		public static void OnReply(ReturnSmeltStoneArg oArg, ReturnSmeltStoneRes oRes)
		{
			XSmeltDocument.Doc.SmeltReturnBack(oRes);
		}

		public static void OnTimeout(ReturnSmeltStoneArg oArg)
		{
		}
	}
}
