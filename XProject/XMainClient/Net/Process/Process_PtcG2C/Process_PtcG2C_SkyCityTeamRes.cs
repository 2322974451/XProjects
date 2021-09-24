using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SkyCityTeamRes
	{

		public static void Process(PtcG2C_SkyCityTeamRes roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleTeamInfo(roPtc);
		}
	}
}
