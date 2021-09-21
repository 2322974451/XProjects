using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200156F RID: 5487
	internal class Process_RpcC2M_GroupChatFindTeamInfoList
	{
		// Token: 0x0600EAD7 RID: 60119 RVA: 0x00344E8C File Offset: 0x0034308C
		public static void OnReply(GroupChatFindTeamInfoListC2S oArg, GroupChatFindTeamInfoListS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatFindTeamInfoList(oRes);
		}

		// Token: 0x0600EAD8 RID: 60120 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatFindTeamInfoListC2S oArg)
		{
		}
	}
}
