using System;

namespace XMainClient
{
	// Token: 0x02001523 RID: 5411
	internal class Process_PtcM2C_TarjaBriefNtf
	{
		// Token: 0x0600E9A5 RID: 59813 RVA: 0x00343024 File Offset: 0x00341224
		public static void Process(PtcM2C_TarjaBriefNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetTarja(roPtc.Data.time);
		}
	}
}
