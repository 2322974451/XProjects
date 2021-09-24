using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WeekEnd4v4RoleDataNtf
	{

		public static void Process(PtcG2C_WeekEnd4v4RoleDataNtf roPtc)
		{
			XWeekendPartyDocument specificDocument = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
			specificDocument.OnWeekendPartyBattleInfoNtf(roPtc.Data);
		}
	}
}
