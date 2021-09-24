using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GroupChatIssueCount
	{

		public static void Process(PtcM2C_GroupChatIssueCount roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.SysnGroupChatIssueCount(roPtc.Data);
		}
	}
}
