using System;

namespace XMainClient
{
	// Token: 0x020012A2 RID: 4770
	internal class Process_PtcG2C_IdipPunishInfoNtf
	{
		// Token: 0x0600DF68 RID: 57192 RVA: 0x003348D0 File Offset: 0x00332AD0
		public static void Process(PtcG2C_IdipPunishInfoNtf roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPTips(roPtc.Data);
		}
	}
}
