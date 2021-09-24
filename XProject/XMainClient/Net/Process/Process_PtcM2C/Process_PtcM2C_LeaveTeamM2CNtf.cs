using System;
using KKSG;

namespace XMainClient
{

	internal class Process_PtcM2C_LeaveTeamM2CNtf
	{

		public static void Process(PtcM2C_LeaveTeamM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnLeaveTeam((LeaveTeamType)roPtc.Data.errorno);
		}
	}
}
