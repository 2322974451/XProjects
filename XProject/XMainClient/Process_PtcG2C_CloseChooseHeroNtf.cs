using System;

namespace XMainClient
{
	// Token: 0x0200144F RID: 5199
	internal class Process_PtcG2C_CloseChooseHeroNtf
	{
		// Token: 0x0600E646 RID: 58950 RVA: 0x0033E368 File Offset: 0x0033C568
		public static void Process(PtcG2C_CloseChooseHeroNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetUIDeathGoState(false);
		}
	}
}
