using System;

namespace XMainClient
{
	// Token: 0x02001304 RID: 4868
	internal class Process_PtcM2C_QAIDNameNtf
	{
		// Token: 0x0600E0FC RID: 57596 RVA: 0x00336D4C File Offset: 0x00334F4C
		public static void Process(PtcM2C_QAIDNameNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.DealWithNameIndex(roPtc.Data.idname);
		}
	}
}
