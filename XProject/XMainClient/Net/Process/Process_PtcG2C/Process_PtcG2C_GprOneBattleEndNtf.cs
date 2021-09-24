using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GprOneBattleEndNtf
	{

		public static void Process(PtcG2C_GprOneBattleEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveDuelRoundResult(roPtc.Data);
		}
	}
}
