using System;

namespace XMainClient
{

	internal class Process_PtcM2C_AnswerAckNtf
	{

		public static void Process(PtcM2C_AnswerAckNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.AddAnswer2List(roPtc.Data);
		}
	}
}
