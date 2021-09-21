using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001552 RID: 5458
	internal class Process_PtcG2C_ChatNotifyG2C
	{
		// Token: 0x0600EA63 RID: 60003 RVA: 0x003441FC File Offset: 0x003423FC
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
