using System;

namespace XMainClient
{
	// Token: 0x02001426 RID: 5158
	internal class Process_PtcM2C_PayParameterInfoInvalidNtf
	{
		// Token: 0x0600E59F RID: 58783 RVA: 0x0033D358 File Offset: 0x0033B558
		public static void Process(PtcM2C_PayParameterInfoInvalidNtf roPtc)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument.PayParameterNtf();
		}
	}
}
