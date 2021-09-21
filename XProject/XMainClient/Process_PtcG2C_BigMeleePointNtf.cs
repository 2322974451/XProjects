using System;

namespace XMainClient
{
	// Token: 0x0200165E RID: 5726
	internal class Process_PtcG2C_BigMeleePointNtf
	{
		// Token: 0x0600EEC7 RID: 61127 RVA: 0x0034A440 File Offset: 0x00348640
		public static void Process(PtcG2C_BigMeleePointNtf roPtc)
		{
			bool flag = XBigMeleeBattleDocument.Doc.battleHandler != null;
			if (flag)
			{
				XBigMeleeBattleDocument.Doc.battleHandler.SetGetPointAnimation(roPtc.Data.point, roPtc.Data.posxz);
			}
		}
	}
}
