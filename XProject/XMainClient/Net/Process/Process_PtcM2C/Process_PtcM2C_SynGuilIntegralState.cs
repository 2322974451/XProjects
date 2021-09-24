using System;

namespace XMainClient
{

	internal class Process_PtcM2C_SynGuilIntegralState
	{

		public static void Process(PtcM2C_SynGuilIntegralState roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.ReceiveUpdateBattleStatu(roPtc.Data.state);
		}
	}
}
