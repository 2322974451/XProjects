using System;

namespace XMainClient
{
	// Token: 0x020014B8 RID: 5304
	internal class Process_PtcG2C_CountDownNtf
	{
		// Token: 0x0600E7EA RID: 59370 RVA: 0x00340A94 File Offset: 0x0033EC94
		public static void Process(PtcG2C_CountDownNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.LeaveSceneCountDown(roPtc.Data.time);
		}
	}
}
