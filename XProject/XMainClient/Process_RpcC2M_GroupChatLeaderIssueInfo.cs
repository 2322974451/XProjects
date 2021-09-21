using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001577 RID: 5495
	internal class Process_RpcC2M_GroupChatLeaderIssueInfo
	{
		// Token: 0x0600EAFB RID: 60155 RVA: 0x0034511C File Offset: 0x0034331C
		public static void OnReply(GroupChatLeaderIssueInfoC2S oArg, GroupChatLeaderIssueInfoS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderInfo(oRes);
		}

		// Token: 0x0600EAFC RID: 60156 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatLeaderIssueInfoC2S oArg)
		{
		}
	}
}
