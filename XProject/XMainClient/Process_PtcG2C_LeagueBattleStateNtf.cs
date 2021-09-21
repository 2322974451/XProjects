using System;

namespace XMainClient
{
	// Token: 0x02001485 RID: 5253
	internal class Process_PtcG2C_LeagueBattleStateNtf
	{
		// Token: 0x0600E719 RID: 59161 RVA: 0x0033F880 File Offset: 0x0033DA80
		public static void Process(PtcG2C_LeagueBattleStateNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnLeagueBattleStateNtf(roPtc.Data);
		}
	}
}
