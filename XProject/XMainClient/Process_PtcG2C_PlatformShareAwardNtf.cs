using System;

namespace XMainClient
{
	// Token: 0x02001527 RID: 5415
	internal class Process_PtcG2C_PlatformShareAwardNtf
	{
		// Token: 0x0600E9B5 RID: 59829 RVA: 0x003431B4 File Offset: 0x003413B4
		public static void Process(PtcG2C_PlatformShareAwardNtf roPtc)
		{
			XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument.UpdateShareRewardsInfo(roPtc.Data);
		}
	}
}
