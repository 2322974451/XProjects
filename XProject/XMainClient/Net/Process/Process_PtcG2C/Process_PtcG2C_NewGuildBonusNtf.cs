using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NewGuildBonusNtf
	{

		public static void Process(PtcG2C_NewGuildBonusNtf roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.bHasAvailableRedPacket = true;
			specificDocument.SendGuildBonuesLeft();
		}
	}
}
