using System;

namespace XMainClient
{
	// Token: 0x02001521 RID: 5409
	internal class Process_PtcM2C_CustomBattleGMNotify
	{
		// Token: 0x0600E99E RID: 59806 RVA: 0x00342FA4 File Offset: 0x003411A4
		public static void Process(PtcM2C_CustomBattleGMNotify roPtc)
		{
			XCustomBattleDocument specificDocument = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			specificDocument.IsCreateGM = roPtc.Data.isgmcreate;
		}
	}
}
