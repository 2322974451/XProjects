using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200165C RID: 5724
	internal class Process_RpcC2G_GuildPartySummonSpirit
	{
		// Token: 0x0600EEBF RID: 61119 RVA: 0x0034A36C File Offset: 0x0034856C
		public static void OnReply(GuildPartySummonSpiritArg oArg, GuildPartySummonSpiritRes oRes)
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
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GuildCollectSummonSuccess"), "fece00");
				}
			}
		}

		// Token: 0x0600EEC0 RID: 61120 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildPartySummonSpiritArg oArg)
		{
		}
	}
}
