using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200151D RID: 5405
	internal class Process_RpcC2G_ReturnSmeltStone
	{
		// Token: 0x0600E98F RID: 59791 RVA: 0x00342EE5 File Offset: 0x003410E5
		public static void OnReply(ReturnSmeltStoneArg oArg, ReturnSmeltStoneRes oRes)
		{
			XSmeltDocument.Doc.SmeltReturnBack(oRes);
		}

		// Token: 0x0600E990 RID: 59792 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReturnSmeltStoneArg oArg)
		{
		}
	}
}
