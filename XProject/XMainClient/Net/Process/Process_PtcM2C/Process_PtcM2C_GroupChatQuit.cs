using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GroupChatQuit
	{

		public static void Process(PtcM2C_GroupChatQuit roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResQuitGroup(roPtc.Data.groupchatID);
		}
	}
}
