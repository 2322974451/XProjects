using System;

namespace XMainClient
{

	internal class Process_PtcM2C_PushQuestionNtf
	{

		public static void Process(PtcM2C_PushQuestionNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.SetQuestion((int)roPtc.Data.serialNum, roPtc.Data.qid);
		}
	}
}
