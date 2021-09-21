using System;

namespace XMainClient
{
	// Token: 0x02001336 RID: 4918
	internal class Process_PtcG2C_GardenPlantEventNotice
	{
		// Token: 0x0600E1C7 RID: 57799 RVA: 0x00338154 File Offset: 0x00336354
		public static void Process(PtcG2C_GardenPlantEventNotice roPtc)
		{
			HomePlantDocument.Doc.OnGetHomeEventBack(roPtc);
		}
	}
}
