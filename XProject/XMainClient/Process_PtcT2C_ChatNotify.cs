using System;

namespace XMainClient
{

	internal class Process_PtcT2C_ChatNotify
	{

		public static void Process(PtcT2C_ChatNotify roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.OnReceiveChatInfo(roPtc.Data.chatinfo);
		}
	}
}
