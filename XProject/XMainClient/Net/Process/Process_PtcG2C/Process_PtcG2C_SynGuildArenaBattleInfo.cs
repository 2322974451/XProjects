using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SynGuildArenaBattleInfo
	{

		public static void Process(PtcG2C_SynGuildArenaBattleInfo roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnSynGuildArenaBattleInfos(roPtc.Data);
		}
	}
}
