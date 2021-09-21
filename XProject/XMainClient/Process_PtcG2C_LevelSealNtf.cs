using System;

namespace XMainClient
{
	// Token: 0x02001103 RID: 4355
	internal class Process_PtcG2C_LevelSealNtf
	{
		// Token: 0x0600D8CB RID: 55499 RVA: 0x0032A0C4 File Offset: 0x003282C4
		public static void Process(PtcG2C_LevelSealNtf roPtc)
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			specificDocument.UseLevelSealInfo(roPtc);
		}
	}
}
