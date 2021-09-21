using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015E6 RID: 5606
	internal class Process_RpcC2M_GoalAwardsGetList
	{
		// Token: 0x0600ECC5 RID: 60613 RVA: 0x003477D8 File Offset: 0x003459D8
		public static void OnReply(GoalAwardsGetList_C2M oArg, GoalAwardsGetList_M2C oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XTargetRewardDocument specificDocument = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
				specificDocument.OnResTargetRewardType(oArg, oRes);
			}
		}

		// Token: 0x0600ECC6 RID: 60614 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GoalAwardsGetList_C2M oArg)
		{
		}
	}
}
