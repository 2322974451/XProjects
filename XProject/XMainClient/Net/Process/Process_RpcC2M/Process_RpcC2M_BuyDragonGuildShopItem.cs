using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_BuyDragonGuildShopItem
	{

		public static void OnReply(BuyDragonGuildShopItemArg oArg, BuyDragonGuildShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		public static void OnTimeout(BuyDragonGuildShopItemArg oArg)
		{
		}
	}
}
