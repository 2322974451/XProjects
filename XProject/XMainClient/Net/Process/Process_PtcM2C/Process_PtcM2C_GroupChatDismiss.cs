using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GroupChatDismiss
	{

		public static void Process(PtcM2C_GroupChatDismiss roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResDismissGroup(roPtc.Data.groupchatID, roPtc.Data.roleid);
		}
	}
}
