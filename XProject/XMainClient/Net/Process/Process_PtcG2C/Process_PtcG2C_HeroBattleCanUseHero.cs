using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleCanUseHero
	{

		public static void Process(PtcG2C_HeroBattleCanUseHero roPtc)
		{
			XHeroBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			specificDocument.SetHeroBattleCanUseHero(roPtc.Data);
		}
	}
}
