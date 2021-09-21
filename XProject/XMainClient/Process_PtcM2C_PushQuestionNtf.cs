using System;

namespace XMainClient
{
	// Token: 0x02001306 RID: 4870
	internal class Process_PtcM2C_PushQuestionNtf
	{
		// Token: 0x0600E103 RID: 57603 RVA: 0x00336DCC File Offset: 0x00334FCC
		public static void Process(PtcM2C_PushQuestionNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.SetQuestion((int)roPtc.Data.serialNum, roPtc.Data.qid);
		}
	}
}
