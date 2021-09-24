using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GardenPlantEventNotice
	{

		public static void Process(PtcG2C_GardenPlantEventNotice roPtc)
		{
			HomePlantDocument.Doc.OnGetHomeEventBack(roPtc);
		}
	}
}
