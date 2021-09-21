using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001341 RID: 4929
	internal class Process_RpcC2M_ReqPlatFriendRankList
	{
		// Token: 0x0600E1F8 RID: 57848 RVA: 0x003385CC File Offset: 0x003367CC
		public static void OnReply(ReqPlatFriendRankListArg oArg, ReqPlatFriendRankListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
					specificDocument.OnReqPlatFriendsRank(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E1F9 RID: 57849 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqPlatFriendRankListArg oArg)
		{
		}
	}
}
