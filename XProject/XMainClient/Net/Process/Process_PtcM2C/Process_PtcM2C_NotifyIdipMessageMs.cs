using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyIdipMessageMs
	{

		public static void Process(PtcM2C_NotifyIdipMessageMs roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPMessage(roPtc.Data);
		}
	}
}
