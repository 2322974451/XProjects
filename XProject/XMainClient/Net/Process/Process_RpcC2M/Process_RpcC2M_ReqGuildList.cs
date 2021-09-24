using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildList
	{

		public static void OnReply(FetchGuildListArg oArg, FetchGuildListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oArg.reason == 2;
					if (flag3)
					{
						XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
						specificDocument.OnGetGuildList(oArg, oRes);
					}
					else
					{
						bool flag4 = oArg.reason == 3;
						if (!flag4)
						{
							XGuildListDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
							specificDocument2.OnGetGuildList(oArg, oRes);
						}
					}
				}
			}
		}

		public static void OnTimeout(FetchGuildListArg oArg)
		{
		}
	}
}
