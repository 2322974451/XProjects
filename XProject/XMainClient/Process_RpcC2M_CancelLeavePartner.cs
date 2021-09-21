using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013F3 RID: 5107
	internal class Process_RpcC2M_CancelLeavePartner
	{
		// Token: 0x0600E4D0 RID: 58576 RVA: 0x0033C281 File Offset: 0x0033A481
		public static void OnReply(CancelLeavePartnerArg oArg, CancelLeavePartnerRes oRes)
		{
			XPartnerDocument.Doc.OnCancleLeavePartnerBack(oRes);
		}

		// Token: 0x0600E4D1 RID: 58577 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CancelLeavePartnerArg oArg)
		{
		}
	}
}
