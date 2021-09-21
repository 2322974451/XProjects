using System;

namespace XMainClient
{
	// Token: 0x02001193 RID: 4499
	internal class Process_PtcG2C_NotifyWatchData
	{
		// Token: 0x0600DB14 RID: 56084 RVA: 0x0032E720 File Offset: 0x0032C920
		public static void Process(PtcG2C_NotifyWatchData roPtc)
		{
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.DealWithTeamMessage(roPtc.Data);
		}
	}
}
