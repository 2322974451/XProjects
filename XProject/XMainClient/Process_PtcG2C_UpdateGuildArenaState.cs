using System;

namespace XMainClient
{
	// Token: 0x0200116F RID: 4463
	internal class Process_PtcG2C_UpdateGuildArenaState
	{
		// Token: 0x0600DA90 RID: 55952 RVA: 0x0032DD20 File Offset: 0x0032BF20
		public static void Process(PtcG2C_UpdateGuildArenaState roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnUpdateGuildArenaState(roPtc.Data);
		}
	}
}
