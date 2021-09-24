using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleOverTime
	{

		public static void Process(PtcG2C_HeroBattleOverTime roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.StartHeroBattleAddTime((int)roPtc.Data.millisecond);
		}
	}
}
