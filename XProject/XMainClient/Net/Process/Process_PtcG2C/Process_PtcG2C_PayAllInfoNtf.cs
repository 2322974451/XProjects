using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PayAllInfoNtf
	{

		public static void Process(PtcG2C_PayAllInfoNtf roPtc)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument.PayAllInfoNtf(roPtc.Data);
			XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument2.PayAllInfoNtf(roPtc.Data);
		}
	}
}
