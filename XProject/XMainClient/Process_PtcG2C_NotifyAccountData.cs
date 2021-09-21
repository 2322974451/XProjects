using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ED2 RID: 3794
	internal class Process_PtcG2C_NotifyAccountData
	{
		// Token: 0x0600C8FC RID: 51452 RVA: 0x002CFBA4 File Offset: 0x002CDDA4
		public static void Process(PtcG2C_NotifyAccountData roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog("Receive PtcG2C_NotifyAccountData", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XAttributeMgr>.singleton.ProcessAccountData(roPtc.Data);
		}
	}
}
