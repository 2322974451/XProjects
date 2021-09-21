using System;

namespace XMainClient
{
	// Token: 0x02001534 RID: 5428
	internal class Process_PtcG2C_MobaBattleTeamRoleNtf
	{
		// Token: 0x0600E9EC RID: 59884 RVA: 0x00343700 File Offset: 0x00341900
		public static void Process(PtcG2C_MobaBattleTeamRoleNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetAllData(roPtc.Data);
		}
	}
}
