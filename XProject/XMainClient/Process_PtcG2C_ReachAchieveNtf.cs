using System;

namespace XMainClient
{
	// Token: 0x020010F4 RID: 4340
	internal class Process_PtcG2C_ReachAchieveNtf
	{
		// Token: 0x0600D88B RID: 55435 RVA: 0x00329B9C File Offset: 0x00327D9C
		public static void Process(PtcG2C_ReachAchieveNtf roPtc)
		{
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			specificDocument.OnReachAhieveNtf(roPtc);
		}
	}
}
