using System;

namespace XMainClient
{

	internal class Process_PtcM2C_IBGiftIconNtf
	{

		public static void Process(PtcM2C_IBGiftIconNtf roPtc)
		{
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.presentStatus = roPtc.Data.status;
			}
		}
	}
}
