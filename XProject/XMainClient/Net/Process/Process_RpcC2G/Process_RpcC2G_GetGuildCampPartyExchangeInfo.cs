using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetGuildCampPartyExchangeInfo
	{

		public static void OnReply(GetGuildCampPartyExchangeInfoArg oArg, GetGuildCampPartyExchangeInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XRequestDocument specificDocument = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
					specificDocument.OnRequestListGet(oRes.infos);
				}
			}
		}

		public static void OnTimeout(GetGuildCampPartyExchangeInfoArg oArg)
		{
		}
	}
}
