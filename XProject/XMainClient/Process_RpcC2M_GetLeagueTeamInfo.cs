using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001463 RID: 5219
	internal class Process_RpcC2M_GetLeagueTeamInfo
	{
		// Token: 0x0600E693 RID: 59027 RVA: 0x0033EBB0 File Offset: 0x0033CDB0
		public static void OnReply(GetLeagueTeamInfoArg oArg, GetLeagueTeamInfoRes oRes)
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
					XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueTeamInfo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E694 RID: 59028 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLeagueTeamInfoArg oArg)
		{
		}
	}
}
