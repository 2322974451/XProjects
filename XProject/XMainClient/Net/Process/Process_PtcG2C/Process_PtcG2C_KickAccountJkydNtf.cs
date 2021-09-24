using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_KickAccountJkydNtf
	{

		public static void Process(PtcG2C_KickAccountJkydNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(roPtc.Data.msg, XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<XLoginDocument>.singleton.OnLoginForbidClick), 50);
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
		}
	}
}
