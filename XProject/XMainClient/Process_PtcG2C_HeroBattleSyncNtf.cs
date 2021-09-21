using System;

namespace XMainClient
{
	// Token: 0x0200141D RID: 5149
	internal class Process_PtcG2C_HeroBattleSyncNtf
	{
		// Token: 0x0600E57C RID: 58748 RVA: 0x0033D104 File Offset: 0x0033B304
		public static void Process(PtcG2C_HeroBattleSyncNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleProgressData(roPtc.Data);
		}
	}
}
