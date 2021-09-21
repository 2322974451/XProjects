using System;

namespace XMainClient
{
	// Token: 0x0200112E RID: 4398
	internal class Process_PtcG2C_FlowerRankRewardNtf
	{
		// Token: 0x0600D97B RID: 55675 RVA: 0x0032B27C File Offset: 0x0032947C
		public static void Process(PtcG2C_FlowerRankRewardNtf roPtc)
		{
			XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			specificDocument.CanGetAwardNtf();
		}
	}
}
