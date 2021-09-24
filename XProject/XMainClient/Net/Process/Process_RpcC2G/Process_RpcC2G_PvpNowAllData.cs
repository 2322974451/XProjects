using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_PvpNowAllData
	{

		public static void OnReply(roArg oArg, PvpNowGameData oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				bool bNoShowLog = oArg.bNoShowLog;
				if (bNoShowLog)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
			}
			else
			{
				XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
				specificDocument.SetReqBattleCaptainPVPRefreshInfo(oArg, oRes);
			}
		}

		public static void OnTimeout(roArg oArg)
		{
		}
	}
}
