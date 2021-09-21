using System;

namespace XMainClient
{
	// Token: 0x02001300 RID: 4864
	internal class Process_PtcM2C_QAOverNtf
	{
		// Token: 0x0600E0EE RID: 57582 RVA: 0x00336C38 File Offset: 0x00334E38
		public static void Process(PtcM2C_QAOverNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.VoiceQAStatement(roPtc.Data.total, roPtc.Data.correct, roPtc.Data.dataList);
		}
	}
}
