using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_RefreshSweepReward
	{

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

		public static void OnTimeout(RefreshSweepRewardArg oArg)
		{
		}
	}
}
