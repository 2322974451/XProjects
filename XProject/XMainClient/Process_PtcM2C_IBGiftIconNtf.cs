using System;

namespace XMainClient
{
	// Token: 0x020014F7 RID: 5367
	internal class Process_PtcM2C_IBGiftIconNtf
	{
		// Token: 0x0600E8F1 RID: 59633 RVA: 0x00341FB8 File Offset: 0x003401B8
		public static void Process(PtcM2C_IBGiftIconNtf roPtc)
		{
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.presentStatus = roPtc.Data.status;
			}
		}
	}
}
