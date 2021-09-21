using System;

namespace XMainClient
{
	// Token: 0x020015BC RID: 5564
	internal class Process_PtcM2C_GroupChatIssueCount
	{
		// Token: 0x0600EC15 RID: 60437 RVA: 0x00346938 File Offset: 0x00344B38
		public static void Process(PtcM2C_GroupChatIssueCount roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.SysnGroupChatIssueCount(roPtc.Data);
		}
	}
}
