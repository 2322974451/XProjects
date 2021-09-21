using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001285 RID: 4741
	internal class Process_RpcC2G_SmeltItem
	{
		// Token: 0x0600DEEE RID: 57070 RVA: 0x00333DA9 File Offset: 0x00331FA9
		public static void OnReply(SmeltItemArg oArg, SmeltItemRes oRes)
		{
			XSmeltDocument.Doc.OnSmeltBack(oRes);
		}

		// Token: 0x0600DEEF RID: 57071 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SmeltItemArg oArg)
		{
		}
	}
}
