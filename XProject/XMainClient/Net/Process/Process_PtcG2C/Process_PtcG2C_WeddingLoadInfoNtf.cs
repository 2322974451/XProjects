using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WeddingLoadInfoNtf
	{

		public static void Process(PtcG2C_WeddingLoadInfoNtf roPtc)
		{
			XWeddingDocument.Doc.OnWeddingLoadingInfoNtf(roPtc);
		}
	}
}
