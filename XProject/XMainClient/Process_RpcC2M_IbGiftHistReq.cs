using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014EB RID: 5355
	internal class Process_RpcC2M_IbGiftHistReq
	{
		// Token: 0x0600E8BE RID: 59582 RVA: 0x00341A08 File Offset: 0x0033FC08
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

		// Token: 0x0600E8BF RID: 59583 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(IBGiftHistAllItemArg oArg)
		{
		}
	}
}
