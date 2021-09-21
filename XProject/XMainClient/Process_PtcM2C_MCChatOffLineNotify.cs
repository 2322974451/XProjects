using System;

namespace XMainClient
{
	// Token: 0x0200119D RID: 4509
	internal class Process_PtcM2C_MCChatOffLineNotify
	{
		// Token: 0x0600DB39 RID: 56121 RVA: 0x0032EBFC File Offset: 0x0032CDFC
		public static void Process(PtcM2C_MCChatOffLineNotify roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.ReceiveOfflineMsg(roPtc);
		}
	}
}
