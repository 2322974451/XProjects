using System;

namespace XMainClient
{
	// Token: 0x020011D5 RID: 4565
	internal class Process_PtcG2C_PayAllInfoNtf
	{
		// Token: 0x0600DC1C RID: 56348 RVA: 0x0032FDEC File Offset: 0x0032DFEC
		public static void Process(PtcG2C_PayAllInfoNtf roPtc)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument.PayAllInfoNtf(roPtc.Data);
			XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument2.PayAllInfoNtf(roPtc.Data);
		}
	}
}
