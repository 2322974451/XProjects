using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatFindRoleInfoList
	{

		public static void OnReply(GroupChatFindRoleInfoListC2S oArg, GroupChatFindRoleInfoListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatFindRoleInfoList(oRes);
		}

		public static void OnTimeout(GroupChatFindRoleInfoListC2S oArg)
		{
		}
	}
}
