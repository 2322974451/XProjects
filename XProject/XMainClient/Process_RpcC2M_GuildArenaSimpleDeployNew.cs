using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012C7 RID: 4807
	internal class Process_RpcC2M_GuildArenaSimpleDeployNew
	{
		// Token: 0x0600E002 RID: 57346 RVA: 0x0033571C File Offset: 0x0033391C
		public static void OnReply(GuildArenaSimpleDeployArg oArg, GuildArenaSimpleDeployRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
			}
		}

		// Token: 0x0600E003 RID: 57347 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildArenaSimpleDeployArg oArg)
		{
		}
	}
}
