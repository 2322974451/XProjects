using System;

namespace XMainClient
{
	// Token: 0x0200158B RID: 5515
	internal class Process_PtcM2C_GroupChatDismiss
	{
		// Token: 0x0600EB4E RID: 60238 RVA: 0x003458B4 File Offset: 0x00343AB4
		public static void Process(PtcM2C_GroupChatDismiss roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResDismissGroup(roPtc.Data.groupchatID, roPtc.Data.roleid);
		}
	}
}
