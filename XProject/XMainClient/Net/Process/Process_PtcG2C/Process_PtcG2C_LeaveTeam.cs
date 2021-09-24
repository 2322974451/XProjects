using System;
using KKSG;

namespace XMainClient
{

	internal class Process_PtcG2C_LeaveTeam
	{

		public static void Process(PtcG2C_LeaveTeam roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnLeaveTeam((LeaveTeamType)roPtc.Data.errorno);
		}
	}
}
