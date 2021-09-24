using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatLeaderReview
	{

		public static void OnReply(GroupChatLeaderReviewC2S oArg, GroupChatLeaderReviewS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderReview(oArg, oRes);
		}

		public static void OnTimeout(GroupChatLeaderReviewC2S oArg)
		{
		}
	}
}
