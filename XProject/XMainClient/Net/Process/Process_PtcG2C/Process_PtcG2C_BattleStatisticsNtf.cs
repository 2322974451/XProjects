using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BattleStatisticsNtf
	{

		public static void Process(PtcG2C_BattleStatisticsNtf roPtc)
		{
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.OnGetStatistics(roPtc.Data);
		}
	}
}
