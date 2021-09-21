using System;

namespace XMainClient
{
	// Token: 0x020015EA RID: 5610
	internal class Process_PtcM2C_GoalAwardsRedPoint
	{
		// Token: 0x0600ECD6 RID: 60630 RVA: 0x00347954 File Offset: 0x00345B54
		public static void Process(PtcM2C_GoalAwardsRedPoint roPtc)
		{
			XTargetRewardDocument specificDocument = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
			specificDocument.SetRedPointList(roPtc.Data.typelist);
		}
	}
}
