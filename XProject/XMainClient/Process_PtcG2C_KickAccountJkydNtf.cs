using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001664 RID: 5732
	internal class Process_PtcG2C_KickAccountJkydNtf
	{
		// Token: 0x0600EEDC RID: 61148 RVA: 0x0034A5D8 File Offset: 0x003487D8
		public static void Process(PtcG2C_KickAccountJkydNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(roPtc.Data.msg, XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<XLoginDocument>.singleton.OnLoginForbidClick), 50);
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
		}
	}
}
