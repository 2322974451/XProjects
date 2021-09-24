using System;

namespace XMainClient
{

	internal class Process_PtcG2C_DisplayAddItem
	{

		public static void Process(PtcG2C_DisplayAddItem roPtc)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.ItemUpdate(roPtc.Data.add_item_id, roPtc.Data.del_item_id);
		}
	}
}
