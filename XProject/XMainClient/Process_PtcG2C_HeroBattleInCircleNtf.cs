using System;

namespace XMainClient
{
	// Token: 0x0200141F RID: 5151
	internal class Process_PtcG2C_HeroBattleInCircleNtf
	{
		// Token: 0x0600E583 RID: 58755 RVA: 0x0033D180 File Offset: 0x0033B380
		public static void Process(PtcG2C_HeroBattleInCircleNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleInCircleData(roPtc.Data);
		}
	}
}
