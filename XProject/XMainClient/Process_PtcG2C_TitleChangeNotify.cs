using System;

namespace XMainClient
{
	// Token: 0x0200121E RID: 4638
	internal class Process_PtcG2C_TitleChangeNotify
	{
		// Token: 0x0600DD44 RID: 56644 RVA: 0x00331918 File Offset: 0x0032FB18
		public static void Process(PtcG2C_TitleChangeNotify roPtc)
		{
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			specificDocument.TitleLevelChange(roPtc.Data.titleID);
		}
	}
}
