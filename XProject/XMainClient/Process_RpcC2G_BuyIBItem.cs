using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001246 RID: 4678
	internal class Process_RpcC2G_BuyIBItem
	{
		// Token: 0x0600DDEB RID: 56811 RVA: 0x00332904 File Offset: 0x00330B04
		public static void OnReply(IBBuyItemReq oArg, IBBuyItemRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
					specificDocument.OnResBuyItem(oArg, oRes);
				}
				else
				{
					XGameMallDocument specificDocument2 = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
					specificDocument2.isBuying = false;
					string @string = XStringDefineProxy.GetString(oRes.errorcode);
					XSingleton<UiUtility>.singleton.ShowSystemTip(@string, "fece00");
				}
			}
		}

		// Token: 0x0600DDEC RID: 56812 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(IBBuyItemReq oArg)
		{
		}
	}
}
