using System;

namespace XMainClient
{
	// Token: 0x0200155D RID: 5469
	internal class Process_PtcG2C_BMFightTimeNtf
	{
		// Token: 0x0600EA8D RID: 60045 RVA: 0x00344720 File Offset: 0x00342920
		public static void Process(PtcG2C_BMFightTimeNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetBattleTime(roPtc);
		}
	}
}
