using System;

namespace XMainClient
{
	// Token: 0x0200155F RID: 5471
	internal class Process_PtcG2C_BMRoleSceneSyncNtf
	{
		// Token: 0x0600EA94 RID: 60052 RVA: 0x00344798 File Offset: 0x00342998
		public static void Process(PtcG2C_BMRoleSceneSyncNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetBattleData(roPtc);
		}
	}
}
