using System;

namespace XMainClient
{
	// Token: 0x02001250 RID: 4688
	internal class Process_PtcG2C_SynAtlasAttr
	{
		// Token: 0x0600DE13 RID: 56851 RVA: 0x00332CC8 File Offset: 0x00330EC8
		public static void Process(PtcG2C_SynAtlasAttr roPtc)
		{
			XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			specificDocument.OnRefreshAttr(roPtc);
		}
	}
}
