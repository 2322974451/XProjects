using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyShopItem
	{

		public static void OnReply(BuyShopItemArg oArg, BuyShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		public static void OnTimeout(BuyShopItemArg oArg)
		{
		}
	}
}
