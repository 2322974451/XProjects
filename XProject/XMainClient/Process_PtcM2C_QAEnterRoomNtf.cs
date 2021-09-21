using System;

namespace XMainClient
{
	// Token: 0x02000B6C RID: 2924
	internal class Process_PtcM2C_QAEnterRoomNtf
	{
		// Token: 0x0600A924 RID: 43300 RVA: 0x001E1B64 File Offset: 0x001DFD64
		public static void Process(PtcM2C_QAEnterRoomNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.AddEnterRoomInfo2List(roPtc.Data);
		}
	}
}
