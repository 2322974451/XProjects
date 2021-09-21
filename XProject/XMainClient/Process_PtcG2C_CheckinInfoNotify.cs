using System;

namespace XMainClient
{
	// Token: 0x0200103C RID: 4156
	internal class Process_PtcG2C_CheckinInfoNotify
	{
		// Token: 0x0600D59F RID: 54687 RVA: 0x00324640 File Offset: 0x00322840
		public static void Process(PtcG2C_CheckinInfoNotify roPtc)
		{
			XLoginRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLoginRewardDocument>(XLoginRewardDocument.uuID);
			specificDocument.OnCheckinInfoNotify(roPtc.Data);
		}
	}
}
