using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TajieHelpNotify
	{

		public static void Process(PtcG2C_TajieHelpNotify roPtc)
		{
			TaJieHelpDocument.Doc.OnGetPtcMes(roPtc);
		}
	}
}
