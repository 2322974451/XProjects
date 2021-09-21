using System;

namespace XMainClient
{
	// Token: 0x02001069 RID: 4201
	internal class Process_PtcT2C_ChatNotify
	{
		// Token: 0x0600D65C RID: 54876 RVA: 0x00325F84 File Offset: 0x00324184
		public static void Process(PtcT2C_ChatNotify roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.OnReceiveChatInfo(roPtc.Data.chatinfo);
		}
	}
}
