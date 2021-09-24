using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatPlayerIssueInfo
	{

		public static void OnReply(GroupChatPlayerIssueInfoC2S oArg, GroupChatPlayerIssueInfoS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatPlayerInfo(oRes);
		}

		public static void OnTimeout(GroupChatPlayerIssueInfoC2S oArg)
		{
		}
	}
}
