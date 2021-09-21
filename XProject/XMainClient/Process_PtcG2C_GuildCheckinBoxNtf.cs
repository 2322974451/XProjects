using System;

namespace XMainClient
{
	// Token: 0x02001088 RID: 4232
	internal class Process_PtcG2C_GuildCheckinBoxNtf
	{
		// Token: 0x0600D6E2 RID: 55010 RVA: 0x00326DFC File Offset: 0x00324FFC
		public static void Process(PtcG2C_GuildCheckinBoxNtf roPtc)
		{
			XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
			specificDocument.SetChestStateAndProgress(roPtc.Data.processbar, roPtc.Data.boxmask);
		}
	}
}
