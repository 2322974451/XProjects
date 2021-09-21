using System;

namespace XMainClient
{
	// Token: 0x0200104A RID: 4170
	internal class Process_PtcG2C_RewardChangedNtf
	{
		// Token: 0x0600D5DD RID: 54749 RVA: 0x003250B0 File Offset: 0x003232B0
		public static void Process(PtcG2C_RewardChangedNtf roPtc)
		{
			XSystemRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSystemRewardDocument>(XSystemRewardDocument.uuID);
			specificDocument.OnRewardChanged(roPtc.Data);
		}
	}
}
