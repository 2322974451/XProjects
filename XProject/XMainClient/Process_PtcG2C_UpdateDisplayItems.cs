using System;

namespace XMainClient
{
	// Token: 0x02001511 RID: 5393
	internal class Process_PtcG2C_UpdateDisplayItems
	{
		// Token: 0x0600E95C RID: 59740 RVA: 0x0034296C File Offset: 0x00340B6C
		public static void Process(PtcG2C_UpdateDisplayItems roPtc)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.UpdateDisplay(roPtc.Data);
		}
	}
}
