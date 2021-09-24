using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleInCircleNtf
	{

		public static void Process(PtcG2C_HeroBattleInCircleNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleInCircleData(roPtc.Data);
		}
	}
}
