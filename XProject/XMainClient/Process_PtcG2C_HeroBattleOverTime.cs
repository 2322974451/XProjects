using System;

namespace XMainClient
{
	// Token: 0x02001423 RID: 5155
	internal class Process_PtcG2C_HeroBattleOverTime
	{
		// Token: 0x0600E593 RID: 58771 RVA: 0x0033D2B8 File Offset: 0x0033B4B8
		public static void Process(PtcG2C_HeroBattleOverTime roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.StartHeroBattleAddTime((int)roPtc.Data.millisecond);
		}
	}
}
