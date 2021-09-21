using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001143 RID: 4419
	internal class Process_RpcC2G_TeamInviteListReq
	{
		// Token: 0x0600D9D5 RID: 55765 RVA: 0x0032BA74 File Offset: 0x00329C74
		public static void OnReply(TeamInviteArg oArg, TeamInviteRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
				specificDocument.OnGetInviteList(oRes);
			}
		}

		// Token: 0x0600D9D6 RID: 55766 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TeamInviteArg oArg)
		{
		}
	}
}
