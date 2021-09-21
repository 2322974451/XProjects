using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200110F RID: 4367
	internal class Process_RpcC2G_FiveDayRewardReq
	{
		// Token: 0x0600D8FC RID: 55548 RVA: 0x0032A51C File Offset: 0x0032871C
		public static void OnReply(FiveRewardRes oArg, FiveRewardRet oRes)
		{
			bool flag = oRes.ret == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
		}

		// Token: 0x0600D8FD RID: 55549 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FiveRewardRes oArg)
		{
		}
	}
}
