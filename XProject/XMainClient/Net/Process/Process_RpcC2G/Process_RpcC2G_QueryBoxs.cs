using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryBoxs
	{

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

		public static void OnTimeout(QueryBoxsArg oArg)
		{
		}
	}
}
