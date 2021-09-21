using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001280 RID: 4736
	internal class Process_RpcC2G_RiskBuyRequest
	{
		// Token: 0x0600DED9 RID: 57049 RVA: 0x00333C2D File Offset: 0x00331E2D
		public static void OnReply(RiskBuyRequestArg oArg, RiskBuyRequestRes oRes)
		{
			XSuperRiskDocument.Doc.BuyOnlineBoxBack(oRes);
		}

		// Token: 0x0600DEDA RID: 57050 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RiskBuyRequestArg oArg)
		{
		}
	}
}
