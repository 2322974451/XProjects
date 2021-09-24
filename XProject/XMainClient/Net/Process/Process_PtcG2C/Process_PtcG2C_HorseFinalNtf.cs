using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseFinalNtf
	{

		public static void Process(PtcG2C_HorseFinalNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RaceComplete(roPtc.Data);
		}
	}
}
