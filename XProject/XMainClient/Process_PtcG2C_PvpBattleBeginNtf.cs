using System;

namespace XMainClient
{
	// Token: 0x02001120 RID: 4384
	internal class Process_PtcG2C_PvpBattleBeginNtf
	{
		// Token: 0x0600D944 RID: 55620 RVA: 0x0032AC34 File Offset: 0x00328E34
		public static void Process(PtcG2C_PvpBattleBeginNtf roPtc)
		{
			XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument.SetBattleBegin(roPtc);
		}
	}
}
