using System;

namespace XMainClient
{
	// Token: 0x02001095 RID: 4245
	internal class Process_PtcG2C_OnlineRewardNtf
	{
		// Token: 0x0600D714 RID: 55060 RVA: 0x003271D0 File Offset: 0x003253D0
		public static void Process(PtcG2C_OnlineRewardNtf roPtc)
		{
			XOnlineRewardDocument specificDocument = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
			specificDocument.RefreshStatus(roPtc.Data.state, roPtc.Data.timeleft);
		}
	}
}
