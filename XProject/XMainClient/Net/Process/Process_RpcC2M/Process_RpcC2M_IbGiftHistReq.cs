using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_IbGiftHistReq
	{

		public static void OnReply(IBGiftHistAllItemArg oArg, IBGiftHistAllItemRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = oRes.gift == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddWarningLog("Process_RpcC2G_IBGiftHistAllItem gift is nil", null, null, null, null, null);
					}
					else
					{
						List<IBGiftHistItem> allitem = oRes.gift.allitem;
						bool flag4 = allitem != null;
						if (flag4)
						{
							XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
							specificDocument.HandleGiftItems(oArg.type, allitem);
						}
					}
				}
				else
				{
					bool flag5 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
					if (flag5)
					{
						string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
						XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
					}
				}
			}
		}

		public static void OnTimeout(IBGiftHistAllItemArg oArg)
		{
		}
	}
}
