using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001289 RID: 4745
	internal class Process_RpcC2G_RefreshSweepReward
	{
		// Token: 0x0600DEFE RID: 57086 RVA: 0x00333E94 File Offset: 0x00332094
		public static void OnReply(RefreshSweepRewardArg oArg, RefreshSweepRewardRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.RefreshSingleSweepRewardRes(oRes.error, oRes.refreshResult);
		}

		// Token: 0x0600DEFF RID: 57087 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RefreshSweepRewardArg oArg)
		{
		}
	}
}
