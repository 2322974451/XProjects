using System;

namespace XMainClient
{

	internal class Process_PtcM2C_QAEnterRoomNtf
	{

		public static void Process(PtcM2C_QAEnterRoomNtf roPtc)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			specificDocument.AddEnterRoomInfo2List(roPtc.Data);
		}
	}
}
