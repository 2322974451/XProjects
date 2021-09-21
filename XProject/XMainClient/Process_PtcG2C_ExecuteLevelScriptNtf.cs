using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001091 RID: 4241
	internal class Process_PtcG2C_ExecuteLevelScriptNtf
	{
		// Token: 0x0600D704 RID: 55044 RVA: 0x003270DC File Offset: 0x003252DC
		public static void Process(PtcG2C_ExecuteLevelScriptNtf roPtc)
		{
			XSingleton<XLevelScriptMgr>.singleton.RunScript(roPtc.Data.script);
		}
	}
}
