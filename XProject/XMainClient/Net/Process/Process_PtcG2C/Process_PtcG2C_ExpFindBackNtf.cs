using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ExpFindBackNtf
	{

		public static void Process(PtcG2C_ExpFindBackNtf roPtc)
		{
			XFindExpDocument.Doc.OnGetExpInfo(roPtc);
		}
	}
}
