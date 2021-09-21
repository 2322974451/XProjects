using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014F9 RID: 5369
	internal class Process_RpcC2G_GuildCampExchangeOperate
	{
		// Token: 0x0600E8F9 RID: 59641 RVA: 0x0034206C File Offset: 0x0034026C
		public static void OnReply(GuildCampExchangeOperateArg oArg, GuildCampExchangeOperateRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
			}
		}

		// Token: 0x0600E8FA RID: 59642 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildCampExchangeOperateArg oArg)
		{
		}
	}
}
