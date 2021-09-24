using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseCountDownTimeNtf
	{

		public static void Process(PtcG2C_HorseCountDownTimeNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RefreshTime(roPtc.Data);
		}
	}
}
