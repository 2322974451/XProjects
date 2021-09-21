using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001130 RID: 4400
	internal class Process_RpcC2G_GetFlowerReward
	{
		// Token: 0x0600D983 RID: 55683 RVA: 0x0032B320 File Offset: 0x00329520
		public static void OnReply(GetFlowerRewardArg oArg, GetFlowerRewardRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
				specificDocument.OnGetAward(oArg, oRes);
			}
		}

		// Token: 0x0600D984 RID: 55684 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetFlowerRewardArg oArg)
		{
		}
	}
}
