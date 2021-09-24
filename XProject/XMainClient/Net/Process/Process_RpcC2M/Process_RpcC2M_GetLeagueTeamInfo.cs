using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetLeagueTeamInfo
	{

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

		public static void OnTimeout(GetLeagueTeamInfoArg oArg)
		{
		}
	}
}
