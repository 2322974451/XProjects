using System;

namespace XMainClient
{

	internal class Process_PtcM2C_DERankChangNtf
	{

		public static void Process(PtcM2C_DERankChangNtf roPtc)
		{
			XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
			specificDocument.OnNotifyResult(roPtc.Data);
		}
	}
}
