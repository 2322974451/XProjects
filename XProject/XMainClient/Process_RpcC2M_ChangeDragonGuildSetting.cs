using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200162B RID: 5675
	internal class Process_RpcC2M_ChangeDragonGuildSetting
	{
		// Token: 0x0600EDEA RID: 60906 RVA: 0x0034903C File Offset: 0x0034723C
		public static void OnReply(ChangeDragonGuildSettingArg oArg, ChangeDragonGuildSettingRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600EDEB RID: 60907 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeDragonGuildSettingArg oArg)
		{
		}
	}
}
