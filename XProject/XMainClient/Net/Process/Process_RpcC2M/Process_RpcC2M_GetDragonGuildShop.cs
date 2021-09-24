using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetDragonGuildShop
	{

		public static void OnReply(GetDragonGuildShopArg oArg, GetDragonGuildShopRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetGoodsList(oArg, oRes);
		}

		public static void OnTimeout(GetDragonGuildShopArg oArg)
		{
		}
	}
}
