using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LargeRoomLoginParamNtf
	{

		public static void Process(PtcM2C_LargeRoomLoginParamNtf roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.isHost = roPtc.Data.speaker;
		}
	}
}
