using System;

namespace XMainClient
{
	// Token: 0x020010D9 RID: 4313
	internal class Process_PtcG2C_AllyMatchRoleIDNotify
	{
		// Token: 0x0600D81D RID: 55325 RVA: 0x003290EC File Offset: 0x003272EC
		public static void Process(PtcG2C_AllyMatchRoleIDNotify roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			if (bInTeam)
			{
				specificDocument.MyTeam.OnEntityMatchingInfo(roPtc.Data);
			}
		}
	}
}
