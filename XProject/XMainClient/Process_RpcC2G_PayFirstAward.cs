using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001205 RID: 4613
	internal class Process_RpcC2G_PayFirstAward
	{
		// Token: 0x0600DCDA RID: 56538 RVA: 0x00330E80 File Offset: 0x0032F080
		public static void OnReply(PayFirstAwardArg oArg, PayFirstAwardRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayFirstAward(oRes);
		}

		// Token: 0x0600DCDB RID: 56539 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PayFirstAwardArg oArg)
		{
		}
	}
}
