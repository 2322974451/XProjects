using System;

namespace XMainClient
{

	internal class Process_PtcM2C_IdipClearChatNtf
	{

		public static void Process(PtcM2C_IdipClearChatNtf roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.ClearRoleMsg(roPtc.Data.roleid);
			XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument2.IDIPClearRoleMsg(roPtc.Data.roleid);
		}
	}
}
