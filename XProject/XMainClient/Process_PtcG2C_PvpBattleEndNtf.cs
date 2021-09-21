using System;

namespace XMainClient
{
	// Token: 0x02001122 RID: 4386
	internal class Process_PtcG2C_PvpBattleEndNtf
	{
		// Token: 0x0600D94B RID: 55627 RVA: 0x0032ACAC File Offset: 0x00328EAC
		public static void Process(PtcG2C_PvpBattleEndNtf roPtc)
		{
			XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument.SetBattleEnd(roPtc);
		}
	}
}
