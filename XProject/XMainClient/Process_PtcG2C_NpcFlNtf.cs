using System;

namespace XMainClient
{
	// Token: 0x0200161A RID: 5658
	internal class Process_PtcG2C_NpcFlNtf
	{
		// Token: 0x0600EDA2 RID: 60834 RVA: 0x00348A94 File Offset: 0x00346C94
		public static void Process(PtcG2C_NpcFlNtf roPtc)
		{
			XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			specificDocument.OnNpcFeelingChange(roPtc.Data);
		}
	}
}
