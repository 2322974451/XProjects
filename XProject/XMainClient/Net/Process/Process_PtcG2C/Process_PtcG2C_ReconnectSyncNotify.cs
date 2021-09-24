using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ReconnectSyncNotify
	{

		public static void Process(PtcG2C_ReconnectSyncNotify roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Got reconnected data!", null, null, null, null, null);
			XSingleton<XReconnection>.singleton.GetReconnectData(roPtc);
		}
	}
}
