using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfGuildCombatNtf
	{

		public static void Process(PtcG2C_GmfGuildCombatNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveGuildCombatNotify(roPtc.Data);
		}
	}
}
