using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetGuildWageReward
	{

		public static void OnReply(GetGuildWageRewardArg oArg, GetGuildWageReward oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildSalaryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
				specificDocument.ReceiveGuildWageReward(oRes);
			}
		}

		public static void OnTimeout(GetGuildWageRewardArg oArg)
		{
		}
	}
}
