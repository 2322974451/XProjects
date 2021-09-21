using System;

namespace XMainClient
{
	// Token: 0x0200132C RID: 4908
	internal class Process_PtcM2C_NoticeGuildArenaNextTime
	{
		// Token: 0x0600E19E RID: 57758 RVA: 0x00337D54 File Offset: 0x00335F54
		public static void Process(PtcM2C_NoticeGuildArenaNextTime roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.ReceiveGuildArenaNextTime(roPtc.Data);
		}
	}
}
