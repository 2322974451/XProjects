using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ED3 RID: 3795
	internal class Process_PtcT2C_KeepAlivePingReq
	{
		// Token: 0x0600C8FE RID: 51454 RVA: 0x002CFBD0 File Offset: 0x002CDDD0
		public static void Process(PtcT2C_KeepAlivePingReq roPtc)
		{
			PtcC2T_KeepAlivePingAck proto = new PtcC2T_KeepAlivePingAck();
			XSingleton<XClientNetwork>.singleton.Send(proto);
			XSingleton<XDebug>.singleton.AddLog("Keep alive ack", XDebugChannel.XDebug_Network.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
