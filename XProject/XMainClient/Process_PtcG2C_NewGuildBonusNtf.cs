using System;

namespace XMainClient
{
	// Token: 0x02000D90 RID: 3472
	internal class Process_PtcG2C_NewGuildBonusNtf
	{
		// Token: 0x0600BD34 RID: 48436 RVA: 0x00273564 File Offset: 0x00271764
		public static void Process(PtcG2C_NewGuildBonusNtf roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.bHasAvailableRedPacket = true;
			specificDocument.SendGuildBonuesLeft();
		}
	}
}
