using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001655 RID: 5717
	internal class Process_RpcC2G_QueryBoxs
	{
		// Token: 0x0600EEA1 RID: 61089 RVA: 0x0034A0E4 File Offset: 0x003482E4
		public static void OnReply(QueryBoxsArg oArg, QueryBoxsRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
				ErrorCode errorcode = oRes.errorcode;
				if (errorcode != ErrorCode.ERR_SUCCESS)
				{
					if (errorcode != ErrorCode.ERR_QUERYBOX_TIMELEFT)
					{
						if (errorcode != ErrorCode.ERR_INVALID_STATE)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
						}
					}
					else
					{
						specificDocument.SetSelectBoxLeftTime(oRes.timeleft);
					}
				}
				else
				{
					specificDocument.SetBoxsInfo(oRes.boxinfos);
				}
			}
		}

		// Token: 0x0600EEA2 RID: 61090 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryBoxsArg oArg)
		{
		}
	}
}
