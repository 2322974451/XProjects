using System;

namespace XMainClient
{
	// Token: 0x020013FB RID: 5115
	internal class Process_PtcG2C_HorseCountDownTimeNtf
	{
		// Token: 0x0600E4F1 RID: 58609 RVA: 0x0033C540 File Offset: 0x0033A740
		public static void Process(PtcG2C_HorseCountDownTimeNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RefreshTime(roPtc.Data);
		}
	}
}
