using System;

namespace XMainClient
{

	internal class Process_PtcM2C_QARoomRankNtf
	{

		public static void Process(PtcM2C_QARoomRankNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.SetRankList(roPtc.Data.dataList, roPtc.Data.myscore);
		}
	}
}
