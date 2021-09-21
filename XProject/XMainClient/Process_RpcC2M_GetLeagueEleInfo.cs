using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001496 RID: 5270
	internal class Process_RpcC2M_GetLeagueEleInfo
	{
		// Token: 0x0600E761 RID: 59233 RVA: 0x0033FEF4 File Offset: 0x0033E0F4
		public static void OnReply(GetLeagueEleInfoArg oArg, GetLeagueEleInfoRes oRes)
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
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueEleInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(oRes.result), "fece00");
					}
				}
			}
		}

		// Token: 0x0600E762 RID: 59234 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLeagueEleInfoArg oArg)
		{
		}
	}
}
