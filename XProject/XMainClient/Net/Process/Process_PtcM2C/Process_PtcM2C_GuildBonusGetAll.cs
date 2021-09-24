using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildBonusGetAll
	{

		public static void Process(PtcM2C_GuildBonusGetAll roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.ReceiveGuildBonusGetAll(roPtc.Data.bonusID);
		}
	}
}
