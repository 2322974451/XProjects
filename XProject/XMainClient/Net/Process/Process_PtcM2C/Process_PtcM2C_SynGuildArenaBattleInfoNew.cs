using System;

namespace XMainClient
{

	internal class Process_PtcM2C_SynGuildArenaBattleInfoNew
	{

		public static void Process(PtcM2C_SynGuildArenaBattleInfoNew roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnSynGuildArenaBattleInfos(roPtc.Data);
		}
	}
}
