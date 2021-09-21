using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001165 RID: 4453
	internal class Process_RpcC2M_ReturnToSelectRole
	{
		// Token: 0x0600DA66 RID: 55910 RVA: 0x0032D410 File Offset: 0x0032B610
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

		// Token: 0x0600DA67 RID: 55911 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReturnToSelectRoleArg oArg)
		{
		}
	}
}
