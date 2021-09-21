using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001218 RID: 4632
	internal class Process_RpcC2G_CommendFirstPass
	{
		// Token: 0x0600DD2A RID: 56618 RVA: 0x00331459 File Offset: 0x0032F659
		public static void OnReply(CommendFirstPassArg oArg, CommendFirstPassRes oRes)
		{
			FirstPassDocument.Doc.OnGetCommendFirstPass(oRes);
		}

		// Token: 0x0600DD2B RID: 56619 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CommendFirstPassArg oArg)
		{
		}
	}
}
