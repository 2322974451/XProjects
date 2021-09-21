using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200117D RID: 4477
	internal class Process_RpcC2G_GetGoddessTrialRewards
	{
		// Token: 0x0600DAC6 RID: 56006 RVA: 0x0032E194 File Offset: 0x0032C394
		public static void OnReply(GetGoddessTrialRewardsArg oArg, GetGoddessTrialRewardsRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					specificDocument.SetGoddessRewardsCanGetTimes(oRes);
				}
			}
		}

		// Token: 0x0600DAC7 RID: 56007 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGoddessTrialRewardsArg oArg)
		{
		}
	}
}
