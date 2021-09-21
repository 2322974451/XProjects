using System;

namespace XMainClient
{
	// Token: 0x0200117F RID: 4479
	internal class Process_PtcG2C_GuildBossTimeOut
	{
		// Token: 0x0600DACE RID: 56014 RVA: 0x0032E24C File Offset: 0x0032C44C
		public static void Process(PtcG2C_GuildBossTimeOut roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.GuildBossTimeOut();
		}
	}
}
