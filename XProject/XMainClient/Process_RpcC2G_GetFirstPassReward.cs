using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001216 RID: 4630
	internal class Process_RpcC2G_GetFirstPassReward
	{
		// Token: 0x0600DD21 RID: 56609 RVA: 0x003313C9 File Offset: 0x0032F5C9
		public static void OnReply(GetFirstPassRewardArg oArg, GetFirstPassRewardRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassReward(oRes);
		}

		// Token: 0x0600DD22 RID: 56610 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetFirstPassRewardArg oArg)
		{
		}
	}
}
