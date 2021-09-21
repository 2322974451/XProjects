using System;

namespace XMainClient
{
	// Token: 0x02001355 RID: 4949
	internal class Process_PtcG2C_ResWarBattleDataNtf
	{
		// Token: 0x0600E247 RID: 57927 RVA: 0x00338D04 File Offset: 0x00336F04
		public static void Process(PtcG2C_ResWarBattleDataNtf roPtc)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleInfo(roPtc);
		}
	}
}
