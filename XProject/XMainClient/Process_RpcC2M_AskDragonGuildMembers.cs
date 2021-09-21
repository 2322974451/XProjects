using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001637 RID: 5687
	internal class Process_RpcC2M_AskDragonGuildMembers
	{
		// Token: 0x0600EE1C RID: 60956 RVA: 0x003494F1 File Offset: 0x003476F1
		public static void OnReply(DragonGuildMemberArg oArg, DragonGuildMemberRes oRes)
		{
			XDragonGuildDocument.Doc.OnGetMemberList(oRes);
		}

		// Token: 0x0600EE1D RID: 60957 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGuildMemberArg oArg)
		{
		}
	}
}
