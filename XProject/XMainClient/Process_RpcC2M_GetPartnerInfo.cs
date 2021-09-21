using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013E1 RID: 5089
	internal class Process_RpcC2M_GetPartnerInfo
	{
		// Token: 0x0600E482 RID: 58498 RVA: 0x0033BD5D File Offset: 0x00339F5D
		public static void OnReply(GetPartnerInfoArg oArg, GetPartnerInfoRes oRes)
		{
			XPartnerDocument.Doc.OnGetPartnerInfoBack(oRes);
		}

		// Token: 0x0600E483 RID: 58499 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerInfoArg oArg)
		{
		}
	}
}
