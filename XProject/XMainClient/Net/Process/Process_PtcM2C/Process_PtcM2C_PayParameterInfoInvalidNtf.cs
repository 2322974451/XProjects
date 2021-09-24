using System;

namespace XMainClient
{

	internal class Process_PtcM2C_PayParameterInfoInvalidNtf
	{

		public static void Process(PtcM2C_PayParameterInfoInvalidNtf roPtc)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument.PayParameterNtf();
		}
	}
}
