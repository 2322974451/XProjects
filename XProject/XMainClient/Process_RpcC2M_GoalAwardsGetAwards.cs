using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015E8 RID: 5608
	internal class Process_RpcC2M_GoalAwardsGetAwards
	{
		// Token: 0x0600ECCE RID: 60622 RVA: 0x003478AC File Offset: 0x00345AAC
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

		// Token: 0x0600ECCF RID: 60623 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GoalAwardsGetAwards_C2M oArg)
		{
		}
	}
}
