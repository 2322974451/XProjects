using System;

namespace XMainClient
{
	// Token: 0x0200127E RID: 4734
	internal class Process_PtcG2C_RiskBuyNtf
	{
		// Token: 0x0600DED1 RID: 57041 RVA: 0x00333B9C File Offset: 0x00331D9C
		public static void Process(PtcG2C_RiskBuyNtf roPtc)
		{
			XSuperRiskDocument.Doc.RiskBuyNtfBack(roPtc);
		}
	}
}
