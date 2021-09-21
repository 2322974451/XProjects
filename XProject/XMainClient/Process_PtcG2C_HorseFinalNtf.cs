using System;

namespace XMainClient
{
	// Token: 0x020013DF RID: 5087
	internal class Process_PtcG2C_HorseFinalNtf
	{
		// Token: 0x0600E47A RID: 58490 RVA: 0x0033BCB8 File Offset: 0x00339EB8
		public static void Process(PtcG2C_HorseFinalNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RaceComplete(roPtc.Data);
		}
	}
}
