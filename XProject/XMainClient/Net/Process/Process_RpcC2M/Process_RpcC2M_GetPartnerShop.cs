using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetPartnerShop
	{

		public static void OnReply(GetPartnerShopArg oArg, GetPartnerShopRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetGoodsList(oArg, oRes);
		}

		public static void OnTimeout(GetPartnerShopArg oArg)
		{
		}
	}
}
