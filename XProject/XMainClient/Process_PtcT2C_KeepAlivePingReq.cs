using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcT2C_KeepAlivePingReq
	{

		public static void Process(PtcT2C_KeepAlivePingReq roPtc)
		{
			PtcC2T_KeepAlivePingAck proto = new PtcC2T_KeepAlivePingAck();
			XSingleton<XClientNetwork>.singleton.Send(proto);
			XSingleton<XDebug>.singleton.AddLog("Keep alive ack", XDebugChannel.XDebug_Network.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
