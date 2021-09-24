using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryShopItem
	{

		public static void OnReply(QueryShopItemArg oArg, QueryShopItemRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
				specificDocument.OnGetGoodsList(oArg, oRes);
			}
		}

		public static void OnTimeout(QueryShopItemArg oArg)
		{
		}
	}
}
