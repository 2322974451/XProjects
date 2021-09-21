using System;

namespace XMainClient
{
	// Token: 0x02001357 RID: 4951
	internal class Process_PtcG2C_ResWarTeamResOne
	{
		// Token: 0x0600E24E RID: 57934 RVA: 0x00338D7C File Offset: 0x00336F7C
		public static void Process(PtcG2C_ResWarTeamResOne roPtc)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleTeamInfo(roPtc);
		}
	}
}
