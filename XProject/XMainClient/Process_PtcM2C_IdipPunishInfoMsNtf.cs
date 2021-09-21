using System;

namespace XMainClient
{
	// Token: 0x020012A4 RID: 4772
	internal class Process_PtcM2C_IdipPunishInfoMsNtf
	{
		// Token: 0x0600DF6F RID: 57199 RVA: 0x0033494C File Offset: 0x00332B4C
		public static void Process(PtcM2C_IdipPunishInfoMsNtf roPtc)
		{
			XIDIPDocument specificDocument = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
			specificDocument.DealWithIDIPTips(roPtc.Data);
		}
	}
}
