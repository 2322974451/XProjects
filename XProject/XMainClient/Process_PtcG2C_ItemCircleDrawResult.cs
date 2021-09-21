using System;

namespace XMainClient
{
	// Token: 0x020010C1 RID: 4289
	internal class Process_PtcG2C_ItemCircleDrawResult
	{
		// Token: 0x0600D7BF RID: 55231 RVA: 0x00328934 File Offset: 0x00326B34
		public static void Process(PtcG2C_ItemCircleDrawResult roPtc)
		{
			XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			specificDocument.ShowLotteryResult((int)roPtc.Data.index);
		}
	}
}
