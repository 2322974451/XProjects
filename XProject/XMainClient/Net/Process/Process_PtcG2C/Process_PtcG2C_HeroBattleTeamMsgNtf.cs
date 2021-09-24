using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleTeamMsgNtf
	{

		public static void Process(PtcG2C_HeroBattleTeamMsgNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleTeamData(roPtc.Data);
		}
	}
}
