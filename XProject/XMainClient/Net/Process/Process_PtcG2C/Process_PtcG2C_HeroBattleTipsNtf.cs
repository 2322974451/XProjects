using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleTipsNtf
	{

		public static void Process(PtcG2C_HeroBattleTipsNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.GetBattleTips(roPtc.Data.id);
		}
	}
}
