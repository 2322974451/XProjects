using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfBattleStateNtf
	{

		public static void Process(PtcG2C_GmfBattleStateNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnBattleState(roPtc.Data);
		}
	}
}
