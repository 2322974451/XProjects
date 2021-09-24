using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LevelSealNtf
	{

		public static void Process(PtcG2C_LevelSealNtf roPtc)
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			specificDocument.UseLevelSealInfo(roPtc);
		}
	}
}
