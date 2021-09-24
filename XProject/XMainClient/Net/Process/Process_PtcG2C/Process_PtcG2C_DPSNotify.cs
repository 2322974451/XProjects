using System;

namespace XMainClient
{

	internal class Process_PtcG2C_DPSNotify
	{

		public static void Process(PtcG2C_DPSNotify roPtc)
		{
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.OnGetDps((double)roPtc.Data.dps);
		}
	}
}
