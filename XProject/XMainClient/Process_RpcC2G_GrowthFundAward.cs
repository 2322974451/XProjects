using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001207 RID: 4615
	internal class Process_RpcC2G_GrowthFundAward
	{
		// Token: 0x0600DCE3 RID: 56547 RVA: 0x00330F28 File Offset: 0x0032F128
		public static void OnReply(GrowthFundAwardArg oArg, GrowthFundAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetGrowthFundAward(oArg, oRes);
		}

		// Token: 0x0600DCE4 RID: 56548 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GrowthFundAwardArg oArg)
		{
		}
	}
}
