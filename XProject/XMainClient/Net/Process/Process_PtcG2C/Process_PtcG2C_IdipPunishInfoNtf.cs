using System;

namespace XMainClient
{

	internal class Process_PtcG2C_IdipPunishInfoNtf
	{

		public static void Process(PtcG2C_IdipPunishInfoNtf roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPTips(roPtc.Data);
		}
	}
}
