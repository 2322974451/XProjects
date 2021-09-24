using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_BuyPartnerShopItem
	{

		public static void OnReply(BuyPartnerShopItemArg oArg, BuyPartnerShopItemRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetBuy(oArg, oRes);
		}

		public static void OnTimeout(BuyPartnerShopItemArg oArg)
		{
		}
	}
}
