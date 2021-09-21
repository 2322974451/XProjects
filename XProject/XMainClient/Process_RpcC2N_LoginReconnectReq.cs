using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001550 RID: 5456
	internal class Process_RpcC2N_LoginReconnectReq
	{
		// Token: 0x0600EA5B RID: 59995 RVA: 0x0034413C File Offset: 0x0034233C
		public static void OnReply(LoginReconnectReqArg oArg, LoginReconnectReqRes oRes)
		{
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				XSingleton<XLoginDocument>.singleton.FromLogining();
			}
		}

		// Token: 0x0600EA5C RID: 59996 RVA: 0x00344197 File Offset: 0x00342397
		public static void OnTimeout(LoginReconnectReqArg oArg)
		{
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
		}
	}
}
