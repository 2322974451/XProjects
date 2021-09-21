using System;

namespace XMainClient
{
	// Token: 0x02001308 RID: 4872
	internal class Process_PtcM2C_QARoomRankNtf
	{
		// Token: 0x0600E10A RID: 57610 RVA: 0x00336E58 File Offset: 0x00335058
		public static void Process(PtcM2C_QARoomRankNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.SetRankList(roPtc.Data.dataList, roPtc.Data.myscore);
		}
	}
}
