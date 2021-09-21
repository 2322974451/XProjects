using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001052 RID: 4178
	internal class Process_RpcC2G_QueryShopItem
	{
		// Token: 0x0600D600 RID: 54784 RVA: 0x00325638 File Offset: 0x00323838
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

		// Token: 0x0600D601 RID: 54785 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryShopItemArg oArg)
		{
		}
	}
}
