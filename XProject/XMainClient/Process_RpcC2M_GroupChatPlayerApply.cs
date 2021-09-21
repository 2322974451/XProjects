using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200157B RID: 5499
	internal class Process_RpcC2M_GroupChatPlayerApply
	{
		// Token: 0x0600EB0D RID: 60173 RVA: 0x00345264 File Offset: 0x00343464
		public static void OnReply(GroupChatPlayerApplyC2S oArg, GroupChatPlayerApplyS2C oRes)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReceiveGroupChatPlayerApply(oArg, oRes);
		}

		// Token: 0x0600EB0E RID: 60174 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatPlayerApplyC2S oArg)
		{
		}
	}
}
