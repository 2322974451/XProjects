using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaBattleTeamRoleNtf
	{

		public static void Process(PtcG2C_MobaBattleTeamRoleNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetAllData(roPtc.Data);
		}
	}
}
