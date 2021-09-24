using System;

namespace XMainClient
{

	internal class Process_PtcM2C_RoleMatchStateM2CNotify
	{

		public static void Process(PtcM2C_RoleMatchStateM2CNotify roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnRoleMatchStateNotify(roPtc.Data);
		}
	}
}
