using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MCChatOffLineNotify
	{

		public static void Process(PtcM2C_MCChatOffLineNotify roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.ReceiveOfflineMsg(roPtc);
		}
	}
}
