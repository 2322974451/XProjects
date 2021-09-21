using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013C3 RID: 5059
	internal class Process_RpcC2G_QueryQQFriendsVipInfo
	{
		// Token: 0x0600E409 RID: 58377 RVA: 0x0033B25C File Offset: 0x0033945C
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

		// Token: 0x0600E40A RID: 58378 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryQQFriendsVipInfoArg oArg)
		{
		}
	}
}
