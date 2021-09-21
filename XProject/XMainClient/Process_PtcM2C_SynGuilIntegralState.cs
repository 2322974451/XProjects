using System;

namespace XMainClient
{
	// Token: 0x02001376 RID: 4982
	internal class Process_PtcM2C_SynGuilIntegralState
	{
		// Token: 0x0600E2D1 RID: 58065 RVA: 0x003399B0 File Offset: 0x00337BB0
		public static void Process(PtcM2C_SynGuilIntegralState roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.ReceiveUpdateBattleStatu(roPtc.Data.state);
		}
	}
}
