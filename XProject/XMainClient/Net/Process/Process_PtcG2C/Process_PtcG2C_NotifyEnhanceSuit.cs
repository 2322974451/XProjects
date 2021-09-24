using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyEnhanceSuit
	{

		public static void Process(PtcG2C_NotifyEnhanceSuit roPtc)
		{
			XEnhanceDocument.Doc.GetTotalEnhanceLevelBack(roPtc.Data.enhanceSuit);
		}
	}
}
