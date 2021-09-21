using System;

namespace XMainClient
{
	// Token: 0x020013CB RID: 5067
	internal class Process_PtcG2C_HorseWaitTimeNtf
	{
		// Token: 0x0600E426 RID: 58406 RVA: 0x0033B464 File Offset: 0x00339664
		public static void Process(PtcG2C_HorseWaitTimeNtf roPtc)
		{
			XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			specificDocument.SetTime(roPtc.Data.time);
		}
	}
}
