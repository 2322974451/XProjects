using System;

namespace XMainClient
{

	internal class Process_PtcG2C_CloseChooseHeroNtf
	{

		public static void Process(PtcG2C_CloseChooseHeroNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetUIDeathGoState(false);
		}
	}
}
