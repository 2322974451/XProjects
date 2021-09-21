using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001274 RID: 4724
	internal class Process_PtcM2C_NoticeGuildArenaBeginNew
	{
		// Token: 0x0600DEAA RID: 57002 RVA: 0x00333870 File Offset: 0x00331A70
		public static void Process(PtcM2C_NoticeGuildArenaBeginNew roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("NoticeGuildArenaBeginNew : ", roPtc.Data.isstart.ToString(), null, null, null, null);
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.bHasAvailableArenaIcon = roPtc.Data.isstart;
		}
	}
}
