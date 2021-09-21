using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001579 RID: 5497
	internal class Process_RpcC2M_GroupChatLeaderReview
	{
		// Token: 0x0600EB04 RID: 60164 RVA: 0x003451C0 File Offset: 0x003433C0
		public static void OnReply(GroupChatLeaderReviewC2S oArg, GroupChatLeaderReviewS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderReview(oArg, oRes);
		}

		// Token: 0x0600EB05 RID: 60165 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatLeaderReviewC2S oArg)
		{
		}
	}
}
