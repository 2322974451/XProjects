using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013E9 RID: 5097
	internal class Process_RpcC2M_GetPartnerLiveness
	{
		// Token: 0x0600E4A7 RID: 58535 RVA: 0x0033BFA5 File Offset: 0x0033A1A5
		public static void OnReply(GetPartnerLivenessArg oArg, GetPartnerLivenessRes oRes)
		{
			XPartnerDocument.PartnerLivenessData.OnGetPartnerLivenessInfoBack(oRes);
		}

		// Token: 0x0600E4A8 RID: 58536 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerLivenessArg oArg)
		{
		}
	}
}
