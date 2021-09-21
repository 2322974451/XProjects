using System;

namespace XMainClient
{
	// Token: 0x0200126C RID: 4716
	internal class Process_PtcG2C_NotifyEnhanceSuit
	{
		// Token: 0x0600DE8C RID: 56972 RVA: 0x00333698 File Offset: 0x00331898
		public static void Process(PtcG2C_NotifyEnhanceSuit roPtc)
		{
			XEnhanceDocument.Doc.GetTotalEnhanceLevelBack(roPtc.Data.enhanceSuit);
		}
	}
}
