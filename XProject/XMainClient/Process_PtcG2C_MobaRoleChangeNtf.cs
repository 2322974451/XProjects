using System;

namespace XMainClient
{
	// Token: 0x02001536 RID: 5430
	internal class Process_PtcG2C_MobaRoleChangeNtf
	{
		// Token: 0x0600E9F3 RID: 59891 RVA: 0x0034377C File Offset: 0x0034197C
		public static void Process(PtcG2C_MobaRoleChangeNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.OnDataChange(roPtc.Data.changeRole);
		}
	}
}
