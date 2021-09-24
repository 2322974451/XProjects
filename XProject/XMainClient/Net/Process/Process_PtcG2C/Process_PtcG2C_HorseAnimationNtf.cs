using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseAnimationNtf
	{

		public static void Process(PtcG2C_HorseAnimationNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RaceEndLeftTime(roPtc.Data);
		}
	}
}
