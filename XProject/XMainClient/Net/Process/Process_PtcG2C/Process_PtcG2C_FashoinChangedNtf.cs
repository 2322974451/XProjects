using System;

namespace XMainClient
{

	internal class Process_PtcG2C_FashoinChangedNtf
	{

		public static void Process(PtcG2C_FashoinChangedNtf roPtc)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			specificDocument.UpdateFashionData(roPtc.Data);
		}
	}
}
