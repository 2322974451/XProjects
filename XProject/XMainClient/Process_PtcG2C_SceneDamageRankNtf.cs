using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010C7 RID: 4295
	internal class Process_PtcG2C_SceneDamageRankNtf
	{
		// Token: 0x0600D7D5 RID: 55253 RVA: 0x00328B50 File Offset: 0x00326D50
		public static void Process(PtcG2C_SceneDamageRankNtf roPtc)
		{
			XSceneDamageRankDocument xsceneDamageRankDoc = XSingleton<XGame>.singleton.Doc.XSceneDamageRankDoc;
			xsceneDamageRankDoc.OnGetRank(roPtc.Data);
		}
	}
}
