using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_EnemyDorpDoodadNtf
	{

		public static void Process(PtcG2C_EnemyDorpDoodadNtf roPtc)
		{
			for (int i = 0; i < roPtc.Data.doodadInfo.Count; i++)
			{
				XSingleton<XLevelDoodadMgr>.singleton.ReceiveDoodadServerInfo(roPtc.Data.doodadInfo[i]);
			}
		}
	}
}
