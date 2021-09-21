using System;

namespace XMainClient
{
	// Token: 0x020015A8 RID: 5544
	internal class Process_PtcG2C_BattleStatisticsNtf
	{
		// Token: 0x0600EBC9 RID: 60361 RVA: 0x003463D0 File Offset: 0x003445D0
		public static void Process(PtcG2C_BattleStatisticsNtf roPtc)
		{
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.OnGetStatistics(roPtc.Data);
		}
	}
}
