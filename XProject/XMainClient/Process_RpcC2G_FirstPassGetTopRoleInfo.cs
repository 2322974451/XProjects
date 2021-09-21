using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200121A RID: 4634
	internal class Process_RpcC2G_FirstPassGetTopRoleInfo
	{
		// Token: 0x0600DD33 RID: 56627 RVA: 0x003314E9 File Offset: 0x0032F6E9
		public static void OnReply(FirstPassGetTopRoleInfoArg oArg, FirstPassGetTopRoleInfoRes oRes)
		{
			FirstPassDocument.Doc.OnGetFirstPassTopRoleInfo(oRes);
		}

		// Token: 0x0600DD34 RID: 56628 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FirstPassGetTopRoleInfoArg oArg)
		{
		}
	}
}
