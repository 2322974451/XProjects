using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GoalAwardsGetAwards
	{

		public static void OnReply(GoalAwardsGetAwards_C2M oArg, GoalAwardsGetAwards_M2C oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XTargetRewardDocument specificDocument = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
				specificDocument.OnClaimedAchieve(oArg.goalAwardsID, oRes.gottenAwardsIndex);
			}
		}

		public static void OnTimeout(GoalAwardsGetAwards_C2M oArg)
		{
		}
	}
}
