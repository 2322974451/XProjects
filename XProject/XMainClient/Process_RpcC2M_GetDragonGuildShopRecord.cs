using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001643 RID: 5699
	internal class Process_RpcC2M_GetDragonGuildShopRecord
	{
		// Token: 0x0600EE52 RID: 61010 RVA: 0x00349991 File Offset: 0x00347B91
		public static void OnReply(GetDragonGuildShopRecordArg oArg, GetDragonGuildShopRecordRes oRes)
		{
			XDragonGuildDocument.Doc.OnGetShopRecordBack(oRes);
		}

		// Token: 0x0600EE53 RID: 61011 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonGuildShopRecordArg oArg)
		{
		}
	}
}
