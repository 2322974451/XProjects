using System;

namespace XMainClient
{
	// Token: 0x02001567 RID: 5479
	internal class Process_PtcG2C_MobaHintNtf
	{
		// Token: 0x0600EAB4 RID: 60084 RVA: 0x00344B54 File Offset: 0x00342D54
		public static void Process(PtcG2C_MobaHintNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.MobaHintNotify(roPtc.Data);
		}
	}
}
