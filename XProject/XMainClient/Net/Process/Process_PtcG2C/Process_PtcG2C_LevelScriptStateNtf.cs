using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_LevelScriptStateNtf
	{

		public static void Process(PtcG2C_LevelScriptStateNtf roPtc)
		{
			for (int i = 0; i < roPtc.Data.doorStates.Count; i++)
			{
				XSingleton<XLevelScriptMgr>.singleton.SyncWallState(roPtc.Data.doorStates[i].name, roPtc.Data.doorStates[i].isOn);
			}
		}
	}
}
