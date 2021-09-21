using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013E5 RID: 5093
	internal class Process_RpcC2G_TakePartnerChest
	{
		// Token: 0x0600E495 RID: 58517 RVA: 0x0033BE85 File Offset: 0x0033A085
		public static void OnReply(TakePartnerChestArg oArg, TakePartnerChestRes oRes)
		{
			XPartnerDocument.PartnerLivenessData.OnTakePartnerChestBack((int)oArg.index, oRes);
		}

		// Token: 0x0600E496 RID: 58518 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TakePartnerChestArg oArg)
		{
		}
	}
}
