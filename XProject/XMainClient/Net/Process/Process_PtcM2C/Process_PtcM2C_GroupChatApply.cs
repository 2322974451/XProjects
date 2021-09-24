using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GroupChatApply
	{

		public static void Process(PtcM2C_GroupChatApply roPtc)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.bShowMotion = true;
		}
	}
}
