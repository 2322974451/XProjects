using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B62 RID: 2914
	internal class Process_RpcC2M_GetGuildWageReward
	{
		// Token: 0x0600A90B RID: 43275 RVA: 0x001E1878 File Offset: 0x001DFA78
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

		// Token: 0x0600A90C RID: 43276 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildWageRewardArg oArg)
		{
		}
	}
}
