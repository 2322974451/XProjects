using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001054 RID: 4180
	internal class Process_RpcC2G_BuyShopItem
	{
		// Token: 0x0600D609 RID: 54793 RVA: 0x00325704 File Offset: 0x00323904
		public static void OnReply(BuyShopItemArg oArg, BuyShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		// Token: 0x0600D60A RID: 54794 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyShopItemArg oArg)
		{
		}
	}
}
