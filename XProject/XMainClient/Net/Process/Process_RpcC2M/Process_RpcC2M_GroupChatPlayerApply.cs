using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GroupChatPlayerApply
	{

		public static void OnReply(GroupChatPlayerApplyC2S oArg, GroupChatPlayerApplyS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatPlayerApply(oArg, oRes);
		}

		public static void OnTimeout(GroupChatPlayerApplyC2S oArg)
		{
		}
	}
}
