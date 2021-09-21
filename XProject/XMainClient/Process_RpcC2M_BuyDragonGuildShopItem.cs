using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200163F RID: 5695
	internal class Process_RpcC2M_BuyDragonGuildShopItem
	{
		// Token: 0x0600EE40 RID: 60992 RVA: 0x0034984C File Offset: 0x00347A4C
		public static void OnReply(BuyDragonGuildShopItemArg oArg, BuyDragonGuildShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		// Token: 0x0600EE41 RID: 60993 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyDragonGuildShopItemArg oArg)
		{
		}
	}
}
