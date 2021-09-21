using System;

namespace XMainClient
{
	// Token: 0x0200118F RID: 4495
	internal class Process_PtcG2C_NoticeGuildArenaBegin
	{
		// Token: 0x0600DB06 RID: 56070 RVA: 0x0032E620 File Offset: 0x0032C820
		public static void Process(PtcG2C_NoticeGuildArenaBegin roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.bHasAvailableArenaIcon = roPtc.Data.isstart;
		}
	}
}
