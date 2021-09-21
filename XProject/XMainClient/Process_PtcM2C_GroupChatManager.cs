using System;

namespace XMainClient
{
	// Token: 0x02001587 RID: 5511
	internal class Process_PtcM2C_GroupChatManager
	{
		// Token: 0x0600EB40 RID: 60224 RVA: 0x003457B8 File Offset: 0x003439B8
		public static void Process(PtcM2C_GroupChatManager roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResChangePlayer(roPtc.Data);
		}
	}
}
