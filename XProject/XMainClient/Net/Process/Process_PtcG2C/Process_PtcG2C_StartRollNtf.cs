using System;

namespace XMainClient
{

	internal class Process_PtcG2C_StartRollNtf
	{

		public static void Process(PtcG2C_StartRollNtf roPtc)
		{
			XRollDocument specificDocument = XDocuments.GetSpecificDocument<XRollDocument>(XRollDocument.uuID);
			specificDocument.SetRollItem(roPtc.Data.info);
		}
	}
}
