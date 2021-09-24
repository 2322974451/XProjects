using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatLeaderReviewList
	{

		public static void OnReply(GroupChatLeaderReviewListC2S oArg, GroupChatLeaderReviewListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderReviewList(oRes);
		}

		public static void OnTimeout(GroupChatLeaderReviewListC2S oArg)
		{
		}
	}
}
