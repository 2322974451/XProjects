using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleTeamRoleNtf
	{

		public static void Process(PtcG2C_HeroBattleTeamRoleNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleMyTeam(roPtc.Data);
		}
	}
}
