using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MSFlowerRainNtf
	{

		public static void Process(PtcM2C_MSFlowerRainNtf roPtc)
		{
			XFlowerReplyDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			specificDocument.OnShowFlowerRain(roPtc.Data);
		}
	}
}
