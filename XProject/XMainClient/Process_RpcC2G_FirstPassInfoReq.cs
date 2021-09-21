using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001212 RID: 4626
	internal class Process_RpcC2G_FirstPassInfoReq
	{
		// Token: 0x0600DD11 RID: 56593 RVA: 0x003312BD File Offset: 0x0032F4BD
		public static void OnReply(FirstPassInfoReqArg oArg, FirstPassInfoReqRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassInfo(oRes);
		}

		// Token: 0x0600DD12 RID: 56594 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FirstPassInfoReqArg oArg)
		{
		}
	}
}
