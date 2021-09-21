using System;

namespace XMainClient
{
	// Token: 0x02001554 RID: 5460
	internal class Process_PtcG2C_MobaMiniMapNtf
	{
		// Token: 0x0600EA6A RID: 60010 RVA: 0x003442D8 File Offset: 0x003424D8
		public static void Process(PtcG2C_MobaMiniMapNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetMiniMapIcon(roPtc.Data.canSeePosIndex);
		}
	}
}
