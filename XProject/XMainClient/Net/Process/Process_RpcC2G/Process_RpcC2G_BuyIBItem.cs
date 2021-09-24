using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyIBItem
	{

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

		public static void OnTimeout(IBBuyItemReq oArg)
		{
		}
	}
}
