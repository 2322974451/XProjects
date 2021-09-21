using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001409 RID: 5129
	internal class Process_RpcC2M_BuyPartnerShopItem
	{
		// Token: 0x0600E52B RID: 58667 RVA: 0x0033C9B4 File Offset: 0x0033ABB4
		public static void OnReply(BuyPartnerShopItemArg oArg, BuyPartnerShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		// Token: 0x0600E52C RID: 58668 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyPartnerShopItemArg oArg)
		{
		}
	}
}
