using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001453 RID: 5203
	internal class Process_PtcG2C_LevelScriptStateNtf
	{
		// Token: 0x0600E656 RID: 58966 RVA: 0x0033E4E0 File Offset: 0x0033C6E0
		public static void Process(PtcG2C_LevelScriptStateNtf roPtc)
		{
			for (int i = 0; i < roPtc.Data.doorStates.Count; i++)
			{
				XSingleton<XLevelScriptMgr>.singleton.SyncWallState(roPtc.Data.doorStates[i].name, roPtc.Data.doorStates[i].isOn);
			}
		}
	}
}
