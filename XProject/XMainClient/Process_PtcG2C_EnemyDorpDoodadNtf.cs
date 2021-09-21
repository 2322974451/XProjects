using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010A3 RID: 4259
	internal class Process_PtcG2C_EnemyDorpDoodadNtf
	{
		// Token: 0x0600D74C RID: 55116 RVA: 0x00327B30 File Offset: 0x00325D30
		public static void Process(PtcG2C_EnemyDorpDoodadNtf roPtc)
		{
			for (int i = 0; i < roPtc.Data.doodadInfo.Count; i++)
			{
				XSingleton<XLevelDoodadMgr>.singleton.ReceiveDoodadServerInfo(roPtc.Data.doodadInfo[i]);
			}
		}
	}
}
