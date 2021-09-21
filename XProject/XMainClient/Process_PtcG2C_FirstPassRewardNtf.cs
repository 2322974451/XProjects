using System;

namespace XMainClient
{
	// Token: 0x02001214 RID: 4628
	internal class Process_PtcG2C_FirstPassRewardNtf
	{
		// Token: 0x0600DD19 RID: 56601 RVA: 0x00331324 File Offset: 0x0032F524
		public static void Process(PtcG2C_FirstPassRewardNtf roPtc)
		{
			FirstPassDocument.Doc.RefreshOutRedDot(roPtc.Data.hasCommendReward, roPtc.Data.hasFirstPassReward);
		}
	}
}
