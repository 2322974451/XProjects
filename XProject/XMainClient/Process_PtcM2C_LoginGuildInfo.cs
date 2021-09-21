using System;

namespace XMainClient
{
	// Token: 0x02001226 RID: 4646
	internal class Process_PtcM2C_LoginGuildInfo
	{
		// Token: 0x0600DD64 RID: 56676 RVA: 0x00331C64 File Offset: 0x0032FE64
		public static void Process(PtcM2C_LoginGuildInfo roPtc)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			specificDocument.InitData(roPtc);
		}
	}
}
