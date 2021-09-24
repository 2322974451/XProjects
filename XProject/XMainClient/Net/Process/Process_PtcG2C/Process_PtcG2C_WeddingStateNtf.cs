using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WeddingStateNtf
	{

		public static void Process(PtcG2C_WeddingStateNtf roPtc)
		{
			XWeddingDocument.Doc.WeddingStateNtf(roPtc);
		}
	}
}
