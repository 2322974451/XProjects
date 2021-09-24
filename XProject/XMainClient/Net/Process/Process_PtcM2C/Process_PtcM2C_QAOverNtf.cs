using System;

namespace XMainClient
{

	internal class Process_PtcM2C_QAOverNtf
	{

		public static void Process(PtcM2C_QAOverNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.VoiceQAStatement(roPtc.Data.total, roPtc.Data.correct, roPtc.Data.dataList);
		}
	}
}
