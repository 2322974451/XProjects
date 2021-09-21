using System;

namespace XMainClient
{
	// Token: 0x0200150F RID: 5391
	internal class Process_PtcG2C_DisplayAddItem
	{
		// Token: 0x0600E955 RID: 59733 RVA: 0x003428E0 File Offset: 0x00340AE0
		public static void Process(PtcG2C_DisplayAddItem roPtc)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.ItemUpdate(roPtc.Data.add_item_id, roPtc.Data.del_item_id);
		}
	}
}
