using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001575 RID: 5493
	internal class Process_RpcC2M_GroupChatPlayerIssueInfo
	{
		// Token: 0x0600EAF2 RID: 60146 RVA: 0x00345078 File Offset: 0x00343278
		public static void OnReply(GroupChatPlayerIssueInfoC2S oArg, GroupChatPlayerIssueInfoS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatPlayerInfo(oRes);
		}

		// Token: 0x0600EAF3 RID: 60147 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatPlayerIssueInfoC2S oArg)
		{
		}
	}
}
