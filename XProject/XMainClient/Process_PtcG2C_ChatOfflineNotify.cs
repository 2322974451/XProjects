using System;

namespace XMainClient
{
	// Token: 0x0200108D RID: 4237
	internal class Process_PtcG2C_ChatOfflineNotify
	{
		// Token: 0x0600D6F6 RID: 55030 RVA: 0x00326FD8 File Offset: 0x003251D8
		public static void Process(PtcM2C_MCChatOffLineNotify roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.ReceiveOfflineMsg(roPtc);
		}
	}
}
