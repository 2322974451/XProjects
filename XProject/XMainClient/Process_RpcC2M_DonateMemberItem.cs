using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001396 RID: 5014
	internal class Process_RpcC2M_DonateMemberItem
	{
		// Token: 0x0600E353 RID: 58195 RVA: 0x0033A33C File Offset: 0x0033853C
		public static void OnReply(DonateMemberItemArg oArg, DonateMemberItemRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					XGuildDonateDocument.Doc.OnGetDonateMemberReply(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E354 RID: 58196 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DonateMemberItemArg oArg)
		{
		}
	}
}
