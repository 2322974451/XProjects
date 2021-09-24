using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetSweepTowerReward
	{

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

		public static void OnTimeout(GetSweepTowerRewardArg oArg)
		{
		}
	}
}
