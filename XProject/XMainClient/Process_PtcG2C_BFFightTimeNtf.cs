using System;

namespace XMainClient
{
	// Token: 0x02001600 RID: 5632
	internal class Process_PtcG2C_BFFightTimeNtf
	{
		// Token: 0x0600ED31 RID: 60721 RVA: 0x00348080 File Offset: 0x00346280
		public static void Process(PtcG2C_BFFightTimeNtf roPtc)
		{
			XBattleFieldBattleDocument.Doc.SetTime(roPtc);
		}
	}
}
