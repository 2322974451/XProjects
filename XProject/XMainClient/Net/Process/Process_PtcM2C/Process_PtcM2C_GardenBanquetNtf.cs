using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GardenBanquetNtf
	{

		public static void Process(PtcM2C_GardenBanquetNtf roPtc)
		{
			XHomeCookAndPartyDocument.Doc.BeginToFeast(roPtc.Data.banquet_id);
		}
	}
}
