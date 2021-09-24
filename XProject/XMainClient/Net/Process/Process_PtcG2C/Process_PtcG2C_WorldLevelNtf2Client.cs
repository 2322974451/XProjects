using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WorldLevelNtf2Client
	{

		public static void Process(PtcG2C_WorldLevelNtf2Client roPtc)
		{
			XBackFlowDocument.Doc.OnGetWorldLevelNotify(roPtc);
		}
	}
}
