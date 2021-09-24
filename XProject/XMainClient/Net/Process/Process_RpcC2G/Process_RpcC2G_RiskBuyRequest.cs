using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_RiskBuyRequest
	{

		public static void OnReply(RiskBuyRequestArg oArg, RiskBuyRequestRes oRes)
		{
			XSuperRiskDocument.Doc.BuyOnlineBoxBack(oRes);
		}

		public static void OnTimeout(RiskBuyRequestArg oArg)
		{
		}
	}
}
