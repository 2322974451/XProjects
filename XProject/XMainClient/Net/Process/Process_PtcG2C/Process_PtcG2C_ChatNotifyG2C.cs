using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ChatNotifyG2C
	{

		public static void Process(PtcG2C_ChatNotifyG2C roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			bool flag = (ulong)roPtc.Data.chatinfo.channel == (ulong)((long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.Battle)) || (ulong)roPtc.Data.chatinfo.channel == (ulong)((long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.Spectate)) || (ulong)roPtc.Data.chatinfo.channel == (ulong)((long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.Curr));
			if (flag)
			{
				specificDocument.OnReceiveChatInfo(roPtc.Data.chatinfo);
			}
		}
	}
}
