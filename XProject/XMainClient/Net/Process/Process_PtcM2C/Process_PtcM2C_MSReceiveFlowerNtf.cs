using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MSReceiveFlowerNtf
	{

		public static void Process(PtcM2C_MSReceiveFlowerNtf roPtc)
		{
			XFlowerReplyDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			specificDocument.OnReceiveFlower(roPtc.Data);
		}
	}
}
