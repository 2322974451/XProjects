using System;

namespace XMainClient
{
	// Token: 0x0200132A RID: 4906
	internal class Process_PtcG2C_DPSNotify
	{
		// Token: 0x0600E197 RID: 57751 RVA: 0x00337CD0 File Offset: 0x00335ED0
		public static void Process(PtcG2C_DPSNotify roPtc)
		{
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.OnGetDps((double)roPtc.Data.dps);
		}
	}
}
