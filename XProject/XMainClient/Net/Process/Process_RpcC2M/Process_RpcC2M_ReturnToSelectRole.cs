using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReturnToSelectRole
	{

		public static void OnReply(ReturnToSelectRoleArg oArg, ReturnToSelectRoleRes oRes)
		{
			bool flag = oRes == null || !XSingleton<XAttributeMgr>.singleton.ProcessAccountData(oRes.accountData);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XSingleton<XPandoraSDKDocument>.singleton.PandoraLogout();
				XSingleton<XGame>.singleton.SwitchTo(EXStage.SelectChar, 3U);
			}
		}

		public static void OnTimeout(ReturnToSelectRoleArg oArg)
		{
		}
	}
}
