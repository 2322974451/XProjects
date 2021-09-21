using System;

namespace XMainClient
{
	// Token: 0x02000B65 RID: 2917
	internal class Process_PtcG2C_LeagueBattleOneResultNft
	{
		// Token: 0x0600A912 RID: 43282 RVA: 0x001E1904 File Offset: 0x001DFB04
		public static void Process(PtcG2C_LeagueBattleOneResultNft roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnSmallReward(roPtc.Data);
		}
	}
}
