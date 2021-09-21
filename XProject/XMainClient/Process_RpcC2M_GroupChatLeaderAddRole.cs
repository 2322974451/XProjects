using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015A5 RID: 5541
	internal class Process_RpcC2M_GroupChatLeaderAddRole
	{
		// Token: 0x0600EBBC RID: 60348 RVA: 0x00346340 File Offset: 0x00344540
		public static void OnReply(GroupChatLeaderAddRoleC2S oArg, GroupChatLeaderAddRoleS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.RecevieZMLeaderAddRole(oArg, oRes);
		}

		// Token: 0x0600EBBD RID: 60349 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatLeaderAddRoleC2S oArg)
		{
		}
	}
}
