using System;

namespace XMainClient
{
	// Token: 0x02001097 RID: 4247
	internal class Process_PtcG2C_NextDayRewardNtf
	{
		// Token: 0x0600D71B RID: 55067 RVA: 0x0032725C File Offset: 0x0032545C
		public static void Process(PtcG2C_NextDayRewardNtf roPtc)
		{
			XNextDayRewardDocument specificDocument = XDocuments.GetSpecificDocument<XNextDayRewardDocument>(XNextDayRewardDocument.uuID);
			specificDocument.RefreshStatus(roPtc.Data.state, roPtc.Data.timeleft);
		}
	}
}
