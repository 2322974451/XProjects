using System;

namespace XMainClient
{
	// Token: 0x02001191 RID: 4497
	internal class Process_PtcG2C_NotifyGuildBossAddAttr
	{
		// Token: 0x0600DB0D RID: 56077 RVA: 0x0032E6A0 File Offset: 0x0032C8A0
		public static void Process(PtcG2C_NotifyGuildBossAddAttr roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.OnNotifyEncourage(roPtc.Data.count);
		}
	}
}
