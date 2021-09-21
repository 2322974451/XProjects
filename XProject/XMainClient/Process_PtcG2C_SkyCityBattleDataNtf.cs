using System;

namespace XMainClient
{
	// Token: 0x020012FA RID: 4858
	internal class Process_PtcG2C_SkyCityBattleDataNtf
	{
		// Token: 0x0600E0D4 RID: 57556 RVA: 0x00336A80 File Offset: 0x00334C80
		public static void Process(PtcG2C_SkyCityBattleDataNtf roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleInfo(roPtc);
		}
	}
}
