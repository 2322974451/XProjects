using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012B0 RID: 4784
	internal class Process_RpcC2G_GetTowerFirstPassReward
	{
		// Token: 0x0600DFA0 RID: 57248 RVA: 0x00334E80 File Offset: 0x00333080
		public static void OnReply(GetTowerFirstPassRewardArg oArg, GetTowerFirstPassRewardRes oRes)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.GetFirstPassRewardRes(oRes.error);
		}

		// Token: 0x0600DFA1 RID: 57249 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetTowerFirstPassRewardArg oArg)
		{
		}
	}
}
