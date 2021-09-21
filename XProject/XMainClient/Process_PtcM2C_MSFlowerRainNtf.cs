using System;

namespace XMainClient
{
	// Token: 0x020011F2 RID: 4594
	internal class Process_PtcM2C_MSFlowerRainNtf
	{
		// Token: 0x0600DC8F RID: 56463 RVA: 0x003308A4 File Offset: 0x0032EAA4
		public static void Process(PtcM2C_MSFlowerRainNtf roPtc)
		{
			XFlowerReplyDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			specificDocument.OnShowFlowerRain(roPtc.Data);
		}
	}
}
