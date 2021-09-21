using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012E9 RID: 4841
	internal class Process_RpcC2G_GmfReadyReq
	{
		// Token: 0x0600E08F RID: 57487 RVA: 0x00336410 File Offset: 0x00334610
		public static void OnReply(GmfReadyArg oArg, GmfReadyRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnReadyReq(oRes);
		}

		// Token: 0x0600E090 RID: 57488 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GmfReadyArg oArg)
		{
		}
	}
}
