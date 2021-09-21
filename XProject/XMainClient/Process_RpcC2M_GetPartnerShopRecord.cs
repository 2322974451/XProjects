using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001417 RID: 5143
	internal class Process_RpcC2M_GetPartnerShopRecord
	{
		// Token: 0x0600E564 RID: 58724 RVA: 0x0033CEAD File Offset: 0x0033B0AD
		public static void OnReply(GetPartnerShopRecordArg oArg, GetPartnerShopRecordRes oRes)
		{
			XPartnerDocument.Doc.OnGetShopRecordBack(oRes);
		}

		// Token: 0x0600E565 RID: 58725 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerShopRecordArg oArg)
		{
		}
	}
}
