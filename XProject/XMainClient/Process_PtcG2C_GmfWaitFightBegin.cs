using System;

namespace XMainClient
{
	// Token: 0x020011BC RID: 4540
	internal class Process_PtcG2C_GmfWaitFightBegin
	{
		// Token: 0x0600DBB6 RID: 56246 RVA: 0x0032F66C File Offset: 0x0032D86C
		public static void Process(PtcG2C_GmfWaitFightBegin roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnWaitFightBegin(roPtc.Data);
		}
	}
}
