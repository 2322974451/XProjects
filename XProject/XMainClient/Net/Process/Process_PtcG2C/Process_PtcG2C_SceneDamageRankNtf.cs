using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SceneDamageRankNtf
	{

		public static void Process(PtcG2C_SceneDamageRankNtf roPtc)
		{
			XSceneDamageRankDocument xsceneDamageRankDoc = XSingleton<XGame>.singleton.Doc.XSceneDamageRankDoc;
			xsceneDamageRankDoc.OnGetRank(roPtc.Data);
		}
	}
}
