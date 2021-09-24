using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleSyncNtf
	{

		public static void Process(PtcG2C_HeroBattleSyncNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleProgressData(roPtc.Data);
		}
	}
}
