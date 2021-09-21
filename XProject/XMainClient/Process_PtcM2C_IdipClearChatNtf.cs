using System;

namespace XMainClient
{
	// Token: 0x020012A6 RID: 4774
	internal class Process_PtcM2C_IdipClearChatNtf
	{
		// Token: 0x0600DF76 RID: 57206 RVA: 0x003349C8 File Offset: 0x00332BC8
		public static void Process(PtcM2C_IdipClearChatNtf roPtc)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.ClearRoleMsg(roPtc.Data.roleid);
			XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument2.IDIPClearRoleMsg(roPtc.Data.roleid);
		}
	}
}
