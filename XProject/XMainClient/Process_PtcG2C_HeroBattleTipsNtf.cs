using System;

namespace XMainClient
{
	// Token: 0x0200147F RID: 5247
	internal class Process_PtcG2C_HeroBattleTipsNtf
	{
		// Token: 0x0600E700 RID: 59136 RVA: 0x0033F5F4 File Offset: 0x0033D7F4
		public static void Process(PtcG2C_HeroBattleTipsNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.GetBattleTips(roPtc.Data.id);
		}
	}
}
