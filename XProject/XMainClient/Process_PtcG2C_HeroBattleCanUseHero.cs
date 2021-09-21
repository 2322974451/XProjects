using System;

namespace XMainClient
{
	// Token: 0x0200147D RID: 5245
	internal class Process_PtcG2C_HeroBattleCanUseHero
	{
		// Token: 0x0600E6F9 RID: 59129 RVA: 0x0033F578 File Offset: 0x0033D778
		public static void Process(PtcG2C_HeroBattleCanUseHero roPtc)
		{
			XHeroBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			specificDocument.SetHeroBattleCanUseHero(roPtc.Data);
		}
	}
}
