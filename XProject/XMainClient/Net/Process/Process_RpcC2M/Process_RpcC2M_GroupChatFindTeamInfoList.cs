using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatFindTeamInfoList
	{

		public static void OnReply(GroupChatFindTeamInfoListC2S oArg, GroupChatFindTeamInfoListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatFindTeamInfoList(oRes);
		}

		public static void OnTimeout(GroupChatFindTeamInfoListC2S oArg)
		{
		}
	}
}
