using System;

namespace XMainClient
{
	// Token: 0x020012D7 RID: 4823
	internal class Process_PtcG2C_SkyCityTeamRes
	{
		// Token: 0x0600E03F RID: 57407 RVA: 0x00335BA4 File Offset: 0x00333DA4
		public static void Process(PtcG2C_SkyCityTeamRes roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleTeamInfo(roPtc);
		}
	}
}
