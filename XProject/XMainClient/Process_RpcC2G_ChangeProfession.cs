using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001489 RID: 5257
	internal class Process_RpcC2G_ChangeProfession
	{
		// Token: 0x0600E728 RID: 59176 RVA: 0x0033F9B8 File Offset: 0x0033DBB8
		public static void OnReply(ChangeProfessionArg oArg, ChangeProfessionRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600E729 RID: 59177 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeProfessionArg oArg)
		{
		}
	}
}
