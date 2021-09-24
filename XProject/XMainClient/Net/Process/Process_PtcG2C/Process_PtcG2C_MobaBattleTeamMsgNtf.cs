using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaBattleTeamMsgNtf
	{

		public static void Process(PtcG2C_MobaBattleTeamMsgNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetBattleMsg(roPtc.Data.teamdata);
		}
	}
}
