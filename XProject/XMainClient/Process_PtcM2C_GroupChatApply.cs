using System;

namespace XMainClient
{
	// Token: 0x020015BE RID: 5566
	internal class Process_PtcM2C_GroupChatApply
	{
		// Token: 0x0600EC1C RID: 60444 RVA: 0x003469B4 File Offset: 0x00344BB4
		public static void Process(PtcM2C_GroupChatApply roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.bShowMotion = true;
		}
	}
}
