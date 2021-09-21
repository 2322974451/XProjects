using System;

namespace XMainClient
{
	// Token: 0x020013A7 RID: 5031
	internal class Process_PtcG2C_SynGuildInheritNumInfo
	{
		// Token: 0x0600E399 RID: 58265 RVA: 0x0033A8E8 File Offset: 0x00338AE8
		public static void Process(PtcG2C_SynGuildInheritNumInfo roPtc)
		{
			XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			specificDocument.SynInheritBaseInfo(roPtc.Data);
		}
	}
}
