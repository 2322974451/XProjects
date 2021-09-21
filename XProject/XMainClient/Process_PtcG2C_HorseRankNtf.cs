using System;

namespace XMainClient
{
	// Token: 0x020013C9 RID: 5065
	internal class Process_PtcG2C_HorseRankNtf
	{
		// Token: 0x0600E41F RID: 58399 RVA: 0x0033B3E8 File Offset: 0x003395E8
		public static void Process(PtcG2C_HorseRankNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RefreshRank(roPtc.Data);
		}
	}
}
