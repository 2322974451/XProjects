using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200146B RID: 5227
	internal class Process_RpcC2M_LeaveLeagueTeam
	{
		// Token: 0x0600E6B1 RID: 59057 RVA: 0x0033EE14 File Offset: 0x0033D014
		public static void OnReply(LeaveLeagueTeamArg oArg, LeaveLeagueTeamRes oRes)
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
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E6B2 RID: 59058 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LeaveLeagueTeamArg oArg)
		{
		}
	}
}
