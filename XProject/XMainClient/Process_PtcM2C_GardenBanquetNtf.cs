using System;

namespace XMainClient
{
	// Token: 0x02000B60 RID: 2912
	internal class Process_PtcM2C_GardenBanquetNtf
	{
		// Token: 0x0600A906 RID: 43270 RVA: 0x001E1820 File Offset: 0x001DFA20
		public static void Process(PtcM2C_GardenBanquetNtf roPtc)
		{
			XHomeCookAndPartyDocument.Doc.BeginToFeast(roPtc.Data.banquet_id);
		}
	}
}
