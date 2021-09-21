using System;

namespace XMainClient
{
	// Token: 0x0200169F RID: 5791
	internal class Process_PtcG2C_VsPayReviveNtf
	{
		// Token: 0x0600EFD2 RID: 61394 RVA: 0x0034BF34 File Offset: 0x0034A134
		public static void Process(PtcG2C_VsPayReviveNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.NotifyVSPayRevive(roPtc.Data);
		}
	}
}
