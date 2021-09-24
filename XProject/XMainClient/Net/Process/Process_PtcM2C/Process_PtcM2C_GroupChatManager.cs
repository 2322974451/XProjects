using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GroupChatManager
	{

		public static void Process(PtcM2C_GroupChatManager roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ResChangePlayer(roPtc.Data);
		}
	}
}
