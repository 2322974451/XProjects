using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200150D RID: 5389
	internal class Process_RpcC2G_BuyExtraSkillEmblemSlot
	{
		// Token: 0x0600E94D RID: 59725 RVA: 0x00342868 File Offset: 0x00340A68
		public static void OnReply(BuyExtraSkillEmblemSlotArg oArg, BuyExtraSkillEmblemSlotRes oRes)
		{
			XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			specificDocument.OnEmbleSlottingBack(oRes);
		}

		// Token: 0x0600E94E RID: 59726 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyExtraSkillEmblemSlotArg oArg)
		{
		}
	}
}
