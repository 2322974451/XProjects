using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ExecuteLevelScriptNtf
	{

		public static void Process(PtcG2C_ExecuteLevelScriptNtf roPtc)
		{
			XSingleton<XLevelScriptMgr>.singleton.RunScript(roPtc.Data.script);
		}
	}
}
