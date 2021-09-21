using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011EB RID: 4587
	internal class Process_RpcC2M_InvHistoryC2MReq
	{
		// Token: 0x0600DC72 RID: 56434 RVA: 0x003305E0 File Offset: 0x0032E7E0
		public static void OnReply(InvHistoryArg oArg, InvHistoryRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.ret == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
					specificDocument.OnInvHistoryReq(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DC73 RID: 56435 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(InvHistoryArg oArg)
		{
		}
	}
}
