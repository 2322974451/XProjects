using System;

namespace XMainClient
{
	// Token: 0x02001501 RID: 5377
	internal class Process_PtcG2C_AbsPartyNtf
	{
		// Token: 0x0600E91A RID: 59674 RVA: 0x00342330 File Offset: 0x00340530
		public static void Process(PtcG2C_AbsPartyNtf roPtc)
		{
			XAbyssPartyDocument specificDocument = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			specificDocument.SetAbyssIndex(roPtc.Data.aby);
		}
	}
}
