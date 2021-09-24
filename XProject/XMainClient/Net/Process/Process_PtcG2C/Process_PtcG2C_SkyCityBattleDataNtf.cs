using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SkyCityBattleDataNtf
	{

		public static void Process(PtcG2C_SkyCityBattleDataNtf roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleInfo(roPtc);
		}
	}
}
