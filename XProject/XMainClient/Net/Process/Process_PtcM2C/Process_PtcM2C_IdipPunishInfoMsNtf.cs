using System;

namespace XMainClient
{

	internal class Process_PtcM2C_IdipPunishInfoMsNtf
	{

		public static void Process(PtcM2C_IdipPunishInfoMsNtf roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPTips(roPtc.Data);
		}
	}
}
