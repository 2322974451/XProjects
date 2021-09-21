using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011D1 RID: 4561
	internal class Process_RpcC2G_GetPayAllInfo
	{
		// Token: 0x0600DC0B RID: 56331 RVA: 0x0032FCB8 File Offset: 0x0032DEB8
		public static void OnReply(GetPayAllInfoArg oArg, GetPayAllInfoRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayAllInfo(oArg, oRes);
			XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument2.OnGetPayAllInfo(oArg, oRes);
		}

		// Token: 0x0600DC0C RID: 56332 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPayAllInfoArg oArg)
		{
		}
	}
}
