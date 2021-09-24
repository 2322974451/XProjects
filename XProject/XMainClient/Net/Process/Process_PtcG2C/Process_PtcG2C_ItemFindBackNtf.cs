using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ItemFindBackNtf
	{

		public static void Process(PtcG2C_ItemFindBackNtf roPtc)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnPtcFindItemBack();
			specificDocument.OnPtcFirstNotify(roPtc.Data.isDayFirstNofity);
		}
	}
}
