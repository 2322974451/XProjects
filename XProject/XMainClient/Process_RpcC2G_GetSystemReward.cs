using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200104C RID: 4172
	internal class Process_RpcC2G_GetSystemReward
	{
		// Token: 0x0600D5E5 RID: 54757 RVA: 0x0032515C File Offset: 0x0032335C
		public static void OnReply(GetSystemRewardArg oArg, GetSystemRewardRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSystemRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSystemRewardDocument>(XSystemRewardDocument.uuID);
				specificDocument.OnFetchReward(oRes);
			}
		}

		// Token: 0x0600D5E6 RID: 54758 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetSystemRewardArg oArg)
		{
		}
	}
}
