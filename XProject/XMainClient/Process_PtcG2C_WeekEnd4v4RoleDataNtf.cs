using System;

namespace XMainClient
{
	// Token: 0x02001538 RID: 5432
	internal class Process_PtcG2C_WeekEnd4v4RoleDataNtf
	{
		// Token: 0x0600E9FA RID: 59898 RVA: 0x003437FC File Offset: 0x003419FC
		public static void Process(PtcG2C_WeekEnd4v4RoleDataNtf roPtc)
		{
			XWeekendPartyDocument specificDocument = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
			specificDocument.OnWeekendPartyBattleInfoNtf(roPtc.Data);
		}
	}
}
