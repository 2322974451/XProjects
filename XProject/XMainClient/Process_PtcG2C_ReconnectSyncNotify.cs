using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001107 RID: 4359
	internal class Process_PtcG2C_ReconnectSyncNotify
	{
		// Token: 0x0600D8DB RID: 55515 RVA: 0x0032A23C File Offset: 0x0032843C
		public static void Process(PtcG2C_ReconnectSyncNotify roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Got reconnected data!", null, null, null, null, null);
			XSingleton<XReconnection>.singleton.GetReconnectData(roPtc);
		}
	}
}
