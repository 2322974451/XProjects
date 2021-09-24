using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseWaitTimeNtf
	{

		public static void Process(PtcG2C_HorseWaitTimeNtf roPtc)
		{
			XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			specificDocument.SetTime(roPtc.Data.time);
		}
	}
}
