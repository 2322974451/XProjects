using System;

namespace XMainClient
{
	// Token: 0x02001561 RID: 5473
	internal class Process_PtcG2C_BigMeleeReliveNtf
	{
		// Token: 0x0600EA9B RID: 60059 RVA: 0x00344810 File Offset: 0x00342A10
		public static void Process(PtcG2C_BigMeleeReliveNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetReviveTime(roPtc);
		}
	}
}
