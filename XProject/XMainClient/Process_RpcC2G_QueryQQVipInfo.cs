using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013AB RID: 5035
	internal class Process_RpcC2G_QueryQQVipInfo
	{
		// Token: 0x0600E3A8 RID: 58280 RVA: 0x0033A9FC File Offset: 0x00338BFC
		public static void OnReply(QueryQQVipInfoArg oArg, QueryQQVipInfoRes oRes)
		{
			XPlatformAbilityDocument specificDocument = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			specificDocument.OnQueryQQVipInfo(oArg, oRes);
		}

		// Token: 0x0600E3A9 RID: 58281 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryQQVipInfoArg oArg)
		{
		}
	}
}
