using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyAccountData
	{

		public static void Process(PtcG2C_NotifyAccountData roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog("Receive PtcG2C_NotifyAccountData", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XAttributeMgr>.singleton.ProcessAccountData(roPtc.Data);
		}
	}
}
