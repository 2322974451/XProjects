using System;

namespace XMainClient
{
	// Token: 0x02001347 RID: 4935
	internal class Process_PtcG2C_GardenBanquetNotice
	{
		// Token: 0x0600E212 RID: 57874 RVA: 0x00338868 File Offset: 0x00336A68
		public static void Process(PtcG2C_GardenBanquetNotice roPtc)
		{
			XHomeCookAndPartyDocument.Doc.OnGardenFeastPhase(roPtc);
		}
	}
}
