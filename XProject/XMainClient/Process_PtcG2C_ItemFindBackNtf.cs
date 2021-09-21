using System;

namespace XMainClient
{
	// Token: 0x0200123C RID: 4668
	internal class Process_PtcG2C_ItemFindBackNtf
	{
		// Token: 0x0600DDBF RID: 56767 RVA: 0x003324BC File Offset: 0x003306BC
		public static void Process(PtcG2C_ItemFindBackNtf roPtc)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnPtcFindItemBack();
			specificDocument.OnPtcFirstNotify(roPtc.Data.isDayFirstNofity);
		}
	}
}
