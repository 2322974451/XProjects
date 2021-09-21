using System;

namespace XMainClient
{
	// Token: 0x02001532 RID: 5426
	internal class Process_PtcG2C_HeroKillNotify
	{
		// Token: 0x0600E9E5 RID: 59877 RVA: 0x00343684 File Offset: 0x00341884
		public static void Process(PtcG2C_HeroKillNotify roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.MobaKillerNotify(roPtc.Data);
		}
	}
}
