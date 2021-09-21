using System;

namespace XMainClient
{
	// Token: 0x020011B8 RID: 4536
	internal class Process_PtcG2C_NotifyWatchIconNum2Client
	{
		// Token: 0x0600DBA8 RID: 56232 RVA: 0x0032F570 File Offset: 0x0032D770
		public static void Process(PtcG2C_NotifyWatchIconNum2Client roPtc)
		{
			XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			specificDocument.SetLiveCount(roPtc.Data.num);
		}
	}
}
