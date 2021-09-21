using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013E7 RID: 5095
	internal class Process_RpcC2M_GetPartnerDetailInfo
	{
		// Token: 0x0600E49E RID: 58526 RVA: 0x0033BF19 File Offset: 0x0033A119
		public static void OnReply(GetPartnerDetailInfoArg oArg, GetPartnerDetailInfoRes oRes)
		{
			XPartnerDocument.Doc.OnGetPartDetailInfoBack(oRes);
		}

		// Token: 0x0600E49F RID: 58527 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerDetailInfoArg oArg)
		{
		}
	}
}
