using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatLeaderAddRole
	{

		public static void OnReply(GroupChatLeaderAddRoleC2S oArg, GroupChatLeaderAddRoleS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.RecevieZMLeaderAddRole(oArg, oRes);
		}

		public static void OnTimeout(GroupChatLeaderAddRoleC2S oArg)
		{
		}
	}
}
