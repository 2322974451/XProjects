using System;

namespace XMainClient
{
	// Token: 0x020010EA RID: 4330
	internal class Process_PtcG2C_TowerSceneInfoNtf
	{
		// Token: 0x0600D862 RID: 55394 RVA: 0x0032973C File Offset: 0x0032793C
		public static void Process(PtcG2C_TowerSceneInfoNtf roPtc)
		{
			XBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
			specificDocument.RefreshTowerSceneInfo(roPtc);
		}
	}
}
