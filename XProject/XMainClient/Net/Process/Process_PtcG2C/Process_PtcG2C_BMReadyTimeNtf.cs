using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BMReadyTimeNtf
	{

		public static void Process(PtcG2C_BMReadyTimeNtf roPtc)
		{
			XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			specificDocument.SetTime(roPtc.Data.time);
		}
	}
}
