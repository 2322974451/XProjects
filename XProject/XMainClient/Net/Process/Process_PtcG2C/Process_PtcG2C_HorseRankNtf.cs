using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseRankNtf
	{

		public static void Process(PtcG2C_HorseRankNtf roPtc)
		{
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			specificDocument.RefreshRank(roPtc.Data);
		}
	}
}
