using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012F5 RID: 4853
	internal class Process_RpcC2G_InspireReq
	{
		// Token: 0x0600E0BE RID: 57534 RVA: 0x00336914 File Offset: 0x00334B14
		public static void OnReply(InspireArg oArg, InspireRes oRes)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnInspireReq(oRes);
		}

		// Token: 0x0600E0BF RID: 57535 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(InspireArg oArg)
		{
		}
	}
}
