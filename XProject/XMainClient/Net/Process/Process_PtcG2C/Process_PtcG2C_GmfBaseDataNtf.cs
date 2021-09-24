using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfBaseDataNtf
	{

		public static void Process(PtcG2C_GmfBaseDataNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnUpdateGuildArenaBattle(roPtc.Data);
		}
	}
}
