using System;

namespace XMainClient
{
	// Token: 0x020014CE RID: 5326
	internal class Process_PtcG2C_MilitaryrankNtf
	{
		// Token: 0x0600E843 RID: 59459 RVA: 0x003411EC File Offset: 0x0033F3EC
		public static void Process(PtcG2C_MilitaryrankNtf roPtc)
		{
			XMilitaryRankDocument specificDocument = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			specificDocument.SetMyMilitaryRecord(roPtc.Data);
		}
	}
}
