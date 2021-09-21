using System;

namespace XMainClient
{
	// Token: 0x02000B66 RID: 2918
	internal class Process_PtcG2C_LeagueBattleResultNtf
	{
		// Token: 0x0600A914 RID: 43284 RVA: 0x001E192C File Offset: 0x001DFB2C
		public static void Process(PtcG2C_LeagueBattleResultNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnBigReward(roPtc.Data);
		}
	}
}
