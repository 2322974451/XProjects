using System;

namespace XMainClient
{
	// Token: 0x0200141B RID: 5147
	internal class Process_PtcG2C_HeroBattleTeamMsgNtf
	{
		// Token: 0x0600E575 RID: 58741 RVA: 0x0033D088 File Offset: 0x0033B288
		public static void Process(PtcG2C_HeroBattleTeamMsgNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleTeamData(roPtc.Data);
		}
	}
}
