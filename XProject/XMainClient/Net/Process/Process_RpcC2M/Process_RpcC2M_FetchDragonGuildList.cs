using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_FetchDragonGuildList
	{

		public static void OnReply(FetchDragonGuildListArg oArg, FetchDragonGuildRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
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
						specificDocument.OnGetDragonGuildList(oArg, oRes);
					}
					else
					{
						XDragonGuildListDocument.Doc.OnGetDragonGuildList(oArg, oRes);
					}
				}
			}
		}

		public static void OnTimeout(FetchDragonGuildListArg oArg)
		{
		}
	}
}
