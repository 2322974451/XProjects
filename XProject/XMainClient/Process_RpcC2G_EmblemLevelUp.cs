using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ECA RID: 3786
	internal class Process_RpcC2G_EmblemLevelUp
	{
		// Token: 0x0600C8C3 RID: 51395 RVA: 0x002CF2F8 File Offset: 0x002CD4F8
		public static void OnReply(EmblemLevelUpArg oArg, EmblemLevelUpRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
		}

		// Token: 0x0600C8C4 RID: 51396 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EmblemLevelUpArg oArg)
		{
		}
	}
}
