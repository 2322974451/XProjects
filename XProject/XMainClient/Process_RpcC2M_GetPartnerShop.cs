using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001407 RID: 5127
	internal class Process_RpcC2M_GetPartnerShop
	{
		// Token: 0x0600E522 RID: 58658 RVA: 0x0033C910 File Offset: 0x0033AB10
		public static void OnReply(GetPartnerShopArg oArg, GetPartnerShopRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetGoodsList(oArg, oRes);
		}

		// Token: 0x0600E523 RID: 58659 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerShopArg oArg)
		{
		}
	}
}
