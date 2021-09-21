using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013ED RID: 5101
	internal class Process_RpcC2M_LeavePartner
	{
		// Token: 0x0600E4B7 RID: 58551 RVA: 0x0033C099 File Offset: 0x0033A299
		public static void OnReply(LeavePartnerArg oArg, LeavePartnerRes oRes)
		{
			XPartnerDocument.Doc.OnLeavePartnerBack(oRes);
		}

		// Token: 0x0600E4B8 RID: 58552 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LeavePartnerArg oArg)
		{
		}
	}
}
