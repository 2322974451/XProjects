using System;

namespace XMainClient
{
	// Token: 0x020011BA RID: 4538
	internal class Process_PtcG2C_GmfWaitOtherLoad
	{
		// Token: 0x0600DBAF RID: 56239 RVA: 0x0032F5F0 File Offset: 0x0032D7F0
		public static void Process(PtcG2C_GmfWaitOtherLoad roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnWaitOtherLoad(roPtc.Data);
		}
	}
}
