using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfKickNty
	{

		public static void Process(PtcG2C_GmfKickNty roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnBekicked(roPtc.Data);
		}
	}
}
