using System;

namespace XMainClient
{

	internal class Process_PtcG2C_RiftSceneInfoNtf
	{

		public static void Process(PtcG2C_RiftSceneInfoNtf roPtc)
		{
			XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			specificDocument.OnRiftSceneInfo(roPtc.Data);
		}
	}
}
