using System;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateDisplayItems
	{

		public static void Process(PtcG2C_UpdateDisplayItems roPtc)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.UpdateDisplay(roPtc.Data);
		}
	}
}
