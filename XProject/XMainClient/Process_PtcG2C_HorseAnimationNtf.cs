using System;

namespace XMainClient
{
	// Token: 0x020013CD RID: 5069
	internal class Process_PtcG2C_HorseAnimationNtf
	{
		// Token: 0x0600E42D RID: 58413 RVA: 0x0033B4E4 File Offset: 0x003396E4
		public static void Process(PtcG2C_HorseAnimationNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RaceEndLeftTime(roPtc.Data);
		}
	}
}
