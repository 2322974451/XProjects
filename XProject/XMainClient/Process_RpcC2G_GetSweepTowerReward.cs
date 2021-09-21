using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200128B RID: 4747
	internal class Process_RpcC2G_GetSweepTowerReward
	{
		// Token: 0x0600DF07 RID: 57095 RVA: 0x00333F68 File Offset: 0x00332168
		public static void OnReply(GetSweepTowerRewardArg oArg, GetSweepTowerRewardRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				specificDocument.GetSweepSingleTowerRewardRes();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
		}

		// Token: 0x0600DF08 RID: 57096 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetSweepTowerRewardArg oArg)
		{
		}
	}
}
