using System;

namespace XMainClient
{

	internal class Process_PtcM2C_SendGuildBonusNtf
	{

		public static void Process(PtcM2C_SendGuildBonusNtf roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.bHasAvailableFixedRedPoint = roPtc.Data.hasLeftSend;
		}
	}
}
