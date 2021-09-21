using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200137C RID: 4988
	internal class Process_RpcC2G_ItemBuffOp
	{
		// Token: 0x0600E2E7 RID: 58087 RVA: 0x00339B29 File Offset: 0x00337D29
		public static void OnReply(ItemBuffOpArg oArg, ItemBuffOpRes oRes)
		{
			XGuildResContentionBuffDocument.Doc.OnGetPersonalBuffOperationResult(oArg, oRes);
		}

		// Token: 0x0600E2E8 RID: 58088 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ItemBuffOpArg oArg)
		{
		}
	}
}
