using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryQQFriendsVipInfo
	{

		public static void OnReply(QueryQQFriendsVipInfoArg oArg, QueryQQFriendsVipInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.OnGetQQFriendsVipInfo(oArg, oRes);
			}
		}

		public static void OnTimeout(QueryQQFriendsVipInfoArg oArg)
		{
		}
	}
}
