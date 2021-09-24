using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_TeamRequestC2M
	{

		public static void OnReply(TeamOPArg oArg, TeamOPRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
				bool flag2 = oArg.request == TeamOperate.TEAM_QUERYCOUNT;
				if (flag2)
				{
					XActivityDocument.Doc.OnGetDayCount();
				}
			}
			else
			{
				bool flag3 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag3)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					specificDocument.OnGetTeamOp(oArg, oRes);
					bool flag4 = oArg.request == TeamOperate.TEAM_QUERYCOUNT;
					if (flag4)
					{
						XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						specificDocument2.SetTeamCount(oRes);
						XActivityDocument.Doc.OnGetDayCount();
					}
				}
			}
		}

		public static void OnTimeout(TeamOPArg oArg)
		{
		}
	}
}
