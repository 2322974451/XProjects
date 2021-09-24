using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GoalAwardsGetList
	{

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

		public static void OnTimeout(GoalAwardsGetList_C2M oArg)
		{
		}
	}
}
