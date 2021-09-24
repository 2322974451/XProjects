using System;

namespace XMainClient
{

	internal class Process_PtcG2C_DoodadItemUseNtf
	{

		public static void Process(PtcG2C_DoodadItemUseNtf roPtc)
		{
			XRaceDocument.Doc.AddInfo(roPtc.Data);
		}
	}
}
