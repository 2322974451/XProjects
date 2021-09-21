using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001573 RID: 5491
	internal class Process_RpcC2M_GroupChatLeaderReviewList
	{
		// Token: 0x0600EAE9 RID: 60137 RVA: 0x00344FD4 File Offset: 0x003431D4
		public static void OnReply(GroupChatLeaderReviewListC2S oArg, GroupChatLeaderReviewListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderReviewList(oRes);
		}

		// Token: 0x0600EAEA RID: 60138 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatLeaderReviewListC2S oArg)
		{
		}
	}
}
