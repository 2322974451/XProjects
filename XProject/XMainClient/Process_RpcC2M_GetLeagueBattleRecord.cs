using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001490 RID: 5264
	internal class Process_RpcC2M_GetLeagueBattleRecord
	{
		// Token: 0x0600E746 RID: 59206 RVA: 0x0033FC24 File Offset: 0x0033DE24
		public static void OnReply(GetLeagueBattleRecordArg oArg, GetLeagueBattleRecordRes oRes)
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
					XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueBattleRecord(oRes);
				}
			}
		}

		// Token: 0x0600E747 RID: 59207 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLeagueBattleRecordArg oArg)
		{
		}
	}
}
