using System;

namespace XMainClient
{
	// Token: 0x0200139E RID: 5022
	internal class Process_PtcG2C_synGuildInheritExp
	{
		// Token: 0x0600E374 RID: 58228 RVA: 0x0033A650 File Offset: 0x00338850
		public static void Process(PtcG2C_synGuildInheritExp roPtc)
		{
			XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			specificDocument.SynInheritExp(roPtc.Data);
		}
	}
}
