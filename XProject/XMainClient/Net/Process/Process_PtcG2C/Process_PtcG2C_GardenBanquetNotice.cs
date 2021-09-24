using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GardenBanquetNotice
	{

		public static void Process(PtcG2C_GardenBanquetNotice roPtc)
		{
			XHomeCookAndPartyDocument.Doc.OnGardenFeastPhase(roPtc);
		}
	}
}
