using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroKillNotify
	{

		public static void Process(PtcG2C_HeroKillNotify roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.MobaKillerNotify(roPtc.Data);
		}
	}
}
