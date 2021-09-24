using System;

namespace XMainClient
{

	internal class Process_PtcG2C_AllyMatchRoleIDNotify
	{

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
