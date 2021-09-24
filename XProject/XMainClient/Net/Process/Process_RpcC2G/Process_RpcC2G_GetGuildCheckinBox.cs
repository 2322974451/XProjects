using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetGuildCheckinBox
	{

		public static void OnReply(GetGuildCheckinBoxArg oArg, GetGuildCheckinBoxRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
				specificDocument.OnFetchBox(oArg, oRes);
			}
		}

		public static void OnTimeout(GetGuildCheckinBoxArg oArg)
		{
		}
	}
}
