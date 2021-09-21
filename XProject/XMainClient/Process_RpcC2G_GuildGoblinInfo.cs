using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010BD RID: 4285
	internal class Process_RpcC2G_GuildGoblinInfo
	{
		// Token: 0x0600D7B0 RID: 55216 RVA: 0x003287F4 File Offset: 0x003269F4
		public static void OnReply(GuildGoblinInfoArg oArg, GuildGoblinInfoRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorCode == ErrorCode.ERR_SUCCESS;
				if (!flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorCode, "fece00");
				}
			}
		}

		// Token: 0x0600D7B1 RID: 55217 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildGoblinInfoArg oArg)
		{
		}
	}
}
