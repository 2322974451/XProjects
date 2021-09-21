using System;

namespace XMainClient
{
	// Token: 0x02001589 RID: 5513
	internal class Process_PtcM2C_GroupChatQuit
	{
		// Token: 0x0600EB47 RID: 60231 RVA: 0x00345834 File Offset: 0x00343A34
		public static void Process(PtcM2C_GroupChatQuit roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResQuitGroup(roPtc.Data.groupchatID);
		}
	}
}
