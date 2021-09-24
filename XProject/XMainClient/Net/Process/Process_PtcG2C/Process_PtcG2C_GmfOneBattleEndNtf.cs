using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfOneBattleEndNtf
	{

		public static void Process(PtcG2C_GmfOneBattleEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnUpdateBattleEnd(roPtc.Data);
		}
	}
}
