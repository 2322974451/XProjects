using System;

namespace XMainClient
{
	// Token: 0x020012F0 RID: 4848
	internal class Process_PtcG2C_GmfKickNty
	{
		// Token: 0x0600E0AA RID: 57514 RVA: 0x00336684 File Offset: 0x00334884
		public static void Process(PtcG2C_GmfKickNty roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnBekicked(roPtc.Data);
		}
	}
}
