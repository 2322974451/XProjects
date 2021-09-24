using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MakePartnerResultNtf
	{

		public static void Process(PtcM2C_MakePartnerResultNtf roPtc)
		{
			XPartnerDocument.Doc.MakePartnerResult(roPtc);
		}
	}
}
