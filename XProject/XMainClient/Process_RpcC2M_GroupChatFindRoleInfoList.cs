using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001571 RID: 5489
	internal class Process_RpcC2M_GroupChatFindRoleInfoList
	{
		// Token: 0x0600EAE0 RID: 60128 RVA: 0x00344F30 File Offset: 0x00343130
		public static void OnReply(GroupChatFindRoleInfoListC2S oArg, GroupChatFindRoleInfoListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatFindRoleInfoList(oRes);
		}

		// Token: 0x0600EAE1 RID: 60129 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatFindRoleInfoListC2S oArg)
		{
		}
	}
}
