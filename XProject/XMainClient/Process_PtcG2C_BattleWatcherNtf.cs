using System;

namespace XMainClient
{
	// Token: 0x0200118D RID: 4493
	internal class Process_PtcG2C_BattleWatcherNtf
	{
		// Token: 0x0600DAFF RID: 56063 RVA: 0x0032E5A4 File Offset: 0x0032C7A4
		public static void Process(PtcG2C_BattleWatcherNtf roPtc)
		{
			XSpectateLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateLevelRewardDocument>(XSpectateLevelRewardDocument.uuID);
			specificDocument.SetData(roPtc.Data);
		}
	}
}
