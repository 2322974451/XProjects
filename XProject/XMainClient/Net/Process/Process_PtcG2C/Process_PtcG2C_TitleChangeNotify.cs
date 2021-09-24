using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TitleChangeNotify
	{

		public static void Process(PtcG2C_TitleChangeNotify roPtc)
		{
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			specificDocument.TitleLevelChange(roPtc.Data.titleID);
		}
	}
}
