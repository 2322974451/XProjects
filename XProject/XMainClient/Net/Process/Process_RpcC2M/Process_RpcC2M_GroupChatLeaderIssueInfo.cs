using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatLeaderIssueInfo
	{

		public static void OnReply(GroupChatLeaderIssueInfoC2S oArg, GroupChatLeaderIssueInfoS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatLeaderInfo(oRes);
		}

		public static void OnTimeout(GroupChatLeaderIssueInfoC2S oArg)
		{
		}
	}
}
