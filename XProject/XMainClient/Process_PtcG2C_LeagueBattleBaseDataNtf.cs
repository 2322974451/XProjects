using System;

namespace XMainClient
{
	// Token: 0x02000B63 RID: 2915
	internal class Process_PtcG2C_LeagueBattleBaseDataNtf
	{
		// Token: 0x0600A90E RID: 43278 RVA: 0x001E18B4 File Offset: 0x001DFAB4
		public static void Process(PtcG2C_LeagueBattleBaseDataNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.UpdateBattleBaseData(roPtc.Data);
		}
	}
}
