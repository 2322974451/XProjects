using System;

namespace XMainClient
{
	// Token: 0x02001201 RID: 4609
	internal class Process_PtcG2C_StartRollNtf
	{
		// Token: 0x0600DCC9 RID: 56521 RVA: 0x00330D4C File Offset: 0x0032EF4C
		public static void Process(PtcG2C_StartRollNtf roPtc)
		{
			XRollDocument specificDocument = XDocuments.GetSpecificDocument<XRollDocument>(XRollDocument.uuID);
			specificDocument.SetRollItem(roPtc.Data.info);
		}
	}
}
