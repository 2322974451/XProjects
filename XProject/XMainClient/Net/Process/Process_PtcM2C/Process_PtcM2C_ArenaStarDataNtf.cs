using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ArenaStarDataNtf
	{

		public static void Process(PtcM2C_ArenaStarDataNtf roPtc)
		{
			XHallFameDocument.Doc.OnGetSupportInfo(roPtc.Data);
		}
	}
}
