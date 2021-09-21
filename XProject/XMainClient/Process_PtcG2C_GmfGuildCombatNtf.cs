using System;

namespace XMainClient
{
	// Token: 0x0200134D RID: 4941
	internal class Process_PtcG2C_GmfGuildCombatNtf
	{
		// Token: 0x0600E229 RID: 57897 RVA: 0x00338A48 File Offset: 0x00336C48
		public static void Process(PtcG2C_GmfGuildCombatNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveGuildCombatNotify(roPtc.Data);
		}
	}
}
