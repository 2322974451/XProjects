using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyIdipMessageGs
	{

		public static void Process(PtcG2C_NotifyIdipMessageGs roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPMessage(roPtc.Data);
		}
	}
}
