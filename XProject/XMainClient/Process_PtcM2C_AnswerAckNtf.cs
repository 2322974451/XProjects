using System;

namespace XMainClient
{
	// Token: 0x02001302 RID: 4866
	internal class Process_PtcM2C_AnswerAckNtf
	{
		// Token: 0x0600E0F5 RID: 57589 RVA: 0x00336CD0 File Offset: 0x00334ED0
		public static void Process(PtcM2C_AnswerAckNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.AddAnswer2List(roPtc.Data);
		}
	}
}
