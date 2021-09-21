using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001461 RID: 5217
	internal class Process_RpcC2M_GetLeagueBattleInfo
	{
		// Token: 0x0600E68A RID: 59018 RVA: 0x0033EAC8 File Offset: 0x0033CCC8
		public static void OnReply(GetLeagueBattleInfoArg oArg, GetLeagueBattleInfoRes oRes)
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
					XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueBattleInfo(oRes);
				}
			}
		}

		// Token: 0x0600E68B RID: 59019 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLeagueBattleInfoArg oArg)
		{
		}
	}
}
