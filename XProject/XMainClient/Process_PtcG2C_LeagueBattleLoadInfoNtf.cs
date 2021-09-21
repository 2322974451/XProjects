using System;

namespace XMainClient
{
	// Token: 0x02000B64 RID: 2916
	internal class Process_PtcG2C_LeagueBattleLoadInfoNtf
	{
		// Token: 0x0600A910 RID: 43280 RVA: 0x001E18DC File Offset: 0x001DFADC
		public static void Process(PtcG2C_LeagueBattleLoadInfoNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.SetBattlePKInfo(roPtc.Data);
		}
	}
}
