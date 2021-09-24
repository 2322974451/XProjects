using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GmfJoinBattleM2CReq
	{

		public static void Process(PtcM2C_GmfJoinBattleM2CReq roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnGmfJoinBattle(roPtc.Data);
		}
	}
}
