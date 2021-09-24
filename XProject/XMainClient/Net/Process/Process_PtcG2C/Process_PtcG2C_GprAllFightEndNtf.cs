using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GprAllFightEndNtf
	{

		public static void Process(PtcG2C_GprAllFightEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveDuelFinalResult(roPtc.Data);
		}
	}
}
