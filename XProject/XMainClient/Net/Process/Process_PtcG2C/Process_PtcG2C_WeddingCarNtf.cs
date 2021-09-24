using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WeddingCarNtf
	{

		public static void Process(PtcG2C_WeddingCarNtf roPtc)
		{
			XWeddingDocument.Doc.OnGetWeddingCarNtf(roPtc);
		}
	}
}
