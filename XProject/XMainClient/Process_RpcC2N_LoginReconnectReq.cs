using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2N_LoginReconnectReq
	{

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

		public static void OnTimeout(LoginReconnectReqArg oArg)
		{
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
		}
	}
}
