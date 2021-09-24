using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfAllFightEndNtf
	{

		public static void Process(PtcG2C_GmfAllFightEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnAllFightEnd(roPtc.Data);
		}
	}
}
