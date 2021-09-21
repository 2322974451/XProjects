using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011D3 RID: 4563
	internal class Process_RpcC2G_PayCardAward
	{
		// Token: 0x0600DC14 RID: 56340 RVA: 0x0032FD74 File Offset: 0x0032DF74
		public static void OnReply(PayCardAwardArg oArg, PayCardAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetCardDailyDiamond(oArg, oRes);
		}

		// Token: 0x0600DC15 RID: 56341 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PayCardAwardArg oArg)
		{
		}
	}
}
