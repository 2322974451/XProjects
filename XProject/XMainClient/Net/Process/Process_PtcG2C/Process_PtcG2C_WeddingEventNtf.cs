using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WeddingEventNtf
	{

		public static void Process(PtcG2C_WeddingEventNtf roPtc)
		{
			XWeddingDocument.Doc.WeddingSceneEventNtf(roPtc);
		}
	}
}
